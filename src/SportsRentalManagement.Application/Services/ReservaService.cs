using System.Collections.Generic;
using System.Threading.Tasks;
using SportsRentalManagement.Contract.Repositories;
using SportsRentalManagement.Models;
using SportsRentalManagement.Data;

namespace SportsRentalManagement.Application.Services
{
    public interface IReservaService
    {
        Task<IEnumerable<Reserva>> ObtenerTodasLasReservasAsync();
        Task<Reserva> ObtenerReservaPorIdAsync(int id);
        Task AgregarReservaAsync(Reserva reserva);
        Task ActualizarReservaAsync(Reserva reserva);
        Task EliminarReservaAsync(int id);
        Task<IEnumerable<Reserva>> ObtenerReservasPorUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<Reserva>> ObtenerReservasPorEquipoIdAsync(int equipoId);
        Task<IEnumerable<Reserva>> ObtenerReservasActivasAsync();
    }

    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly AppDBContext _context;

        public ReservaService(IReservaRepository reservaRepository, AppDBContext context)
        {
            _reservaRepository = reservaRepository;
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> ObtenerTodasLasReservasAsync()
        {
            return await _reservaRepository.GetAllAsync();
        }

        public async Task<Reserva> ObtenerReservaPorIdAsync(int id)
        {
            return await _reservaRepository.GetByIdAsync(id);
        }

        public async Task AgregarReservaAsync(Reserva reserva)
        {
            await _reservaRepository.AddAsync(reserva);
        }

        public async Task ActualizarReservaAsync(Reserva reserva)
        {
            await _reservaRepository.UpdateAsync(reserva);
        }

        public async Task EliminarReservaAsync(int id)
        {
            await _reservaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Reserva>> ObtenerReservasPorUsuarioIdAsync(int usuarioId)
        {
            return await _reservaRepository.GetByUserIdAsync(usuarioId);
        }

        public async Task<IEnumerable<Reserva>> ObtenerReservasPorEquipoIdAsync(int equipoId)
        {
            return await _reservaRepository.GetByEquipmentIdAsync(equipoId);
        }

        public async Task<IEnumerable<Reserva>> ObtenerReservasActivasAsync()
        {
            return await _reservaRepository.GetActiveReservasAsync();
        }
    }
}