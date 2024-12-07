using SportsRentalManagement.Contract.Repositories;
using SportsRentalManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsRentalManagement.Data;
using System.Linq;

namespace SportsRentalManagement.Infrastructure.Data.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly AppDBContext _context;

        public PagoRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Pago>> GetAllAsync()
        {
            return await _context.Pagos.ToListAsync();
        }

        public async Task<Pago> GetByIdAsync(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }

        public async Task<List<Pago>> GetByReservaIdAsync(int reservaId)
        {
            return await _context.Pagos
                .Where(p => p.ReservaId == reservaId)
                .ToListAsync();
        }

        public async Task AddAsync(Pago pago)
        {
            await _context.Pagos.AddAsync(pago);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pago pago)
        {
            _context.Pagos.Update(pago);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
                await _context.SaveChangesAsync();
            }
        }
    }
}