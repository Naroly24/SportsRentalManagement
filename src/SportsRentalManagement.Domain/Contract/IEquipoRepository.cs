using SportsRentalManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsRentalManagement.Contract.Repositories
{
    public interface IEquipoRepository
    {
        Task<List<Equipo>> GetAllAsync();
        Task<Equipo> GetByIdAsync(int id);
        Task AddAsync(Equipo equipo);
        Task UpdateAsync(Equipo equipo);
        Task DeleteAsync(int id);
    }
}
