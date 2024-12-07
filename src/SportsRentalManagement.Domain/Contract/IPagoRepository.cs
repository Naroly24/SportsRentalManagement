using SportsRentalManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsRentalManagement.Contract.Repositories
{
    public interface IPagoRepository
    {
        Task<List<Pago>> GetAllAsync();
        Task<Pago> GetByIdAsync(int id);
        Task<List<Pago>> GetByReservaIdAsync(int reservaId); 
        Task AddAsync(Pago pago);
        Task UpdateAsync(Pago pago);
        Task DeleteAsync(int id);
    }
}