using SportsRentalManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsRentalManagement.Contract.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}
