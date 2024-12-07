using SportsRentalManagement.Contract.Repositories;
using SportsRentalManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsRentalManagement.Data;

namespace SportsRentalManagement.Infrastructure.Data.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDBContext _context;

        public ReservaRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Reserva>> GetAllAsync()
        {
            return await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .ToListAsync();
        }

        public async Task<Reserva> GetByIdAsync(int id)
        {
            return await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Reserva>> GetByUserIdAsync(int usuarioId)
        {
            return await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .Where(r => r.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<List<Reserva>> GetByEquipmentIdAsync(int equipoId)
        {
            return await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .Where(r => r.EquipoId == equipoId)
                .ToListAsync();
        }

        public async Task<List<Reserva>> GetActiveReservasAsync()
        {
            return await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .Where(r => r.EstadoReserva == "Activa")
                .ToListAsync();
        }
    }
}