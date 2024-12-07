using SportsRentalManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsRentalManagement.Contract.Repositories
{
    public interface IFacturacionRepository
    {
        Task<List<Facturacion>> GetAllAsync();
        Task<Facturacion> GetByIdAsync(int id);
        Task AddAsync(Facturacion facturacion);
        Task UpdateAsync(Facturacion facturacion);
        Task DeleteAsync(int id);
        Task<List<Facturacion>> GetByEstadoAsync(string estadoFactura);
        Task<List<Facturacion>> GetByRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}