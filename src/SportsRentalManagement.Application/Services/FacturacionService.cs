using System;
using System.Collections.Generic;
using SportsRentalManagement.Domain.Interfaces;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Services
{
    public interface IFacturacionService
    {
        IEnumerable<Facturacion> ObtenerTodasLasFacturas();
        Facturacion ObtenerFacturaPorId(int id);
        void AgregarFactura(Facturacion factura);
        void ActualizarFactura(Facturacion factura);
        void EliminarFactura(int id);
        IEnumerable<Facturacion> ObtenerFacturasPorEstado(string estadoFactura);
        IEnumerable<Facturacion> ObtenerFacturasPorRangoFechas(DateTime fechaInicio, DateTime fechaFin);
    }

    public class FacturacionService : IFacturacionService
    {
        private readonly IFacturacionRepository _facturacionRepository;

        public FacturacionService(IFacturacionRepository facturacionRepository)
        {
            _facturacionRepository = facturacionRepository;
        }

        public IEnumerable<Facturacion> ObtenerTodasLasFacturas()
        {
            return _facturacionRepository.ObtenerTodas();
        }

        public Facturacion ObtenerFacturaPorId(int id)
        {
            return _facturacionRepository.ObtenerPorId(id);
        }

        public void AgregarFactura(Facturacion factura)
        {
            _facturacionRepository.Agregar(factura);
        }

        public void ActualizarFactura(Facturacion factura)
        {
            _facturacionRepository.Actualizar(factura);
        }

        public void EliminarFactura(int id)
        {
            _facturacionRepository.Eliminar(id);
        }

        public IEnumerable<Facturacion> ObtenerFacturasPorEstado(string estadoFactura)
        {
            return _facturacionRepository.ObtenerPorEstado(estadoFactura);
        }

        public IEnumerable<Facturacion> ObtenerFacturasPorRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return _facturacionRepository.ObtenerPorRangoFechas(fechaInicio, fechaFin);
        }
    }
}