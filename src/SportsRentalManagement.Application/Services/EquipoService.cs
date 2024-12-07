using System.Collections.Generic;
using System.Threading.Tasks;
using SportsRentalManagement.Contract.Repositories;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly IEquipoRepository _equipoRepository;

        public EquipoService(IEquipoRepository equipoRepository)
        {
            _equipoRepository = equipoRepository;
        }

        public async Task<IEnumerable<Equipo>> GetAllEquiposAsync()
        {
            return await _equipoRepository.GetAllAsync();
        }

        public async Task<Equipo> GetEquipoByIdAsync(int id)
        {
            return await _equipoRepository.GetByIdAsync(id);
        }

        public async Task AddEquipoAsync(Equipo equipo)
        {
            await _equipoRepository.AddAsync(equipo);
        }

        public async Task UpdateEquipoAsync(Equipo equipo)
        {
            await _equipoRepository.UpdateAsync(equipo);
        }

        public async Task DeleteEquipoAsync(int id)
        {
            await _equipoRepository.DeleteAsync(id);
        }
    }

    public interface IEquipoService
    {
        Task<IEnumerable<Equipo>> GetAllEquiposAsync();
        Task<Equipo> GetEquipoByIdAsync(int id);
        Task AddEquipoAsync(Equipo equipo);
        Task UpdateEquipoAsync(Equipo equipo);
        Task DeleteEquipoAsync(int id);
    }
}
