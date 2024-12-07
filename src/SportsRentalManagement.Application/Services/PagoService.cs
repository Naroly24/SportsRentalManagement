using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Contract.Repositories;
using SportsRentalManagement.Models;
using SportsRentalManagement.Data; 

namespace SportsRentalManagement.Application.Services
{
    public interface IPagoService
    {
        Task<IEnumerable<Pago>> ObtenerTodosLosPagosAsync();
        Task<Pago> ObtenerPagoPorIdAsync(int id);
        Task<IEnumerable<Pago>> ObtenerPagosPorReservaIdAsync(int reservaId);
        Task AgregarPagoAsync(Pago pago);
        Task ActualizarPagoAsync(Pago pago);
        Task EliminarPagoAsync(int id);
    }

    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly AppDBContext _context;

        public PagoService(IPagoRepository pagoRepository, AppDBContext context)
        {
            _pagoRepository = pagoRepository;
            _context = context;
        }

        public async Task<IEnumerable<Pago>> ObtenerTodosLosPagosAsync()
        {
            return await _pagoRepository.GetAllAsync();
        }

        public async Task<Pago> ObtenerPagoPorIdAsync(int id)
        {
            return await _pagoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Pago>> ObtenerPagosPorReservaIdAsync(int reservaId)
        {
            return await _context.Pagos
                .Where(p => p.ReservaId == reservaId)
                .ToListAsync();
        }

        public async Task AgregarPagoAsync(Pago pago)
        {
            await _pagoRepository.AddAsync(pago);
        }

        public async Task ActualizarPagoAsync(Pago pago)
        {
            await _pagoRepository.UpdateAsync(pago);
        }

        public async Task EliminarPagoAsync(int id)
        {
            await _pagoRepository.DeleteAsync(id);
        }
    }
}