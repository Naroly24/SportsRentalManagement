using SportsRentalManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsRentalManagement.Contract.Repositories
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> GetAllAsync();
        Task<Reserva> GetByIdAsync(int id);
        Task AddAsync(Reserva reserva);
        Task UpdateAsync(Reserva reserva);
        Task DeleteAsync(int id);
        Task<List<Reserva>> GetByUserIdAsync(int usuarioId);
        Task<List<Reserva>> GetByEquipmentIdAsync(int equipoId);
        Task<List<Reserva>> GetActiveReservasAsync();
    }
}