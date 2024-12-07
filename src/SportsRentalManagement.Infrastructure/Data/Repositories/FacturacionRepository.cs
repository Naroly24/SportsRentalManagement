using SportsRentalManagement.Contract.Repositories;
using SportsRentalManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsRentalManagement.Data;

namespace SportsRentalManagement.Infrastructure.Data.Repositories
{
    public class FacturacionRepository : IFacturacionRepository
    {
        private readonly AppDBContext _context;

        public FacturacionRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Facturacion>> GetAllAsync()
        {
            return await _context.Facturaciones
                .Include(f => f.Reserva)
                .ToListAsync();
        }

        public async Task<Facturacion> GetByIdAsync(int id)
        {
            return await _context.Facturaciones
                .Include(f => f.Reserva)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Facturacion facturacion)
        {
            await _context.Facturaciones.AddAsync(facturacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Facturacion facturacion)
        {
            _context.Facturaciones.Update(facturacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var facturacion = await _context.Facturaciones.FindAsync(id);
            if (facturacion != null)
            {
                _context.Facturaciones.Remove(facturacion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Facturacion>> GetByEstadoAsync(string estadoFactura)
        {
            return await _context.Facturaciones
                .Include(f => f.Reserva)
                .Where(f => f.EstadoFactura == estadoFactura)
                .ToListAsync();
        }

        public async Task<List<Facturacion>> GetByRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Facturaciones
                .Include(f => f.Reserva)
                .Where(f => f.FechaFactura >= fechaInicio && f.FechaFactura <= fechaFin)
                .ToListAsync();
        }
    }
}