using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsRentalManagement.Models;
using SportsRentalManagement.Contract.Repositories;

namespace SportsRentalManagement.Application.Services
{
    public interface IFacturacionService
    {
        Task<IEnumerable<Facturacion>> ObtenerTodasLasFacturasAsync();
        Task<Facturacion> ObtenerFacturaPorIdAsync(int id);
        Task AgregarFacturaAsync(Facturacion factura);
        Task ActualizarFacturaAsync(Facturacion factura);
        Task EliminarFacturaAsync(int id);
        Task<IEnumerable<Facturacion>> ObtenerFacturasPorEstadoAsync(string estadoFactura);
        Task<IEnumerable<Facturacion>> ObtenerFacturasPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
    }

    public class FacturacionService : IFacturacionService
    {
        private readonly IFacturacionRepository _facturacionRepository;

        public FacturacionService(IFacturacionRepository facturacionRepository)
        {
            _facturacionRepository = facturacionRepository;
        }

        public async Task<IEnumerable<Facturacion>> ObtenerTodasLasFacturasAsync()
        {
            return await _facturacionRepository.GetAllAsync();
        }

        public async Task<Facturacion> ObtenerFacturaPorIdAsync(int id)
        {
            return await _facturacionRepository.GetByIdAsync(id);
        }

        public async Task AgregarFacturaAsync(Facturacion factura)
        {
            await _facturacionRepository.AddAsync(factura);
        }

        public async Task ActualizarFacturaAsync(Facturacion factura)
        {
            await _facturacionRepository.UpdateAsync(factura);
        }

        public async Task EliminarFacturaAsync(int id)
        {
            await _facturacionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Facturacion>> ObtenerFacturasPorEstadoAsync(string estadoFactura)
        {
            return await _facturacionRepository.GetByEstadoAsync(estadoFactura);
        }

        public async Task<IEnumerable<Facturacion>> ObtenerFacturasPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _facturacionRepository.GetByRangoFechasAsync(fechaInicio, fechaFin);
        }
    }
}