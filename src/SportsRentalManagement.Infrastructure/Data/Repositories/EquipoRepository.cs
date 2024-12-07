using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Contract.Repositories;
using SportsRentalManagement.Data;
using SportsRentalManagement.Models;

public class EquipoRepository : IEquipoRepository
{
    private readonly AppDBContext _context;

    public EquipoRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<Equipo>> GetAllAsync()
    {
        return await _context.Equipos.ToListAsync();
    }

    public async Task<Equipo> GetByIdAsync(int id)
    {
        return await _context.Equipos.FindAsync(id);
    }

    public async Task AddAsync(Equipo equipo)
    {
        try
        {
            await _context.Equipos.AddAsync(equipo);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occurred while adding the equipo.", ex);
        }
    }

    public async Task UpdateAsync(Equipo equipo)
    {
        var existingEquipo = await _context.Equipos.FindAsync(equipo.Id);
        if (existingEquipo != null)
        {
            _context.Entry(existingEquipo).CurrentValues.SetValues(equipo);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Equipo with ID {equipo.Id} not found.");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var equipo = await _context.Equipos.FindAsync(id);
        if (equipo != null)
        {
            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Equipo with ID {id} not found.");
        }
    }
}
