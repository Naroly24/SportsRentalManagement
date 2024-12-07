using System.Collections.Generic;
using SportsRentalManagement.Domain.Interfaces;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Services
{
    public interface IPagoService
    {
        IEnumerable<Pago> ObtenerTodosLosPagos();
        Pago ObtenerPagoPorId(int id);
        IEnumerable<Pago> ObtenerPagosPorReservaId(int reservaId);
        void AgregarPago(Pago pago);
        void ActualizarPago(Pago pago);
        void EliminarPago(int id);
    }

    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _pagoRepository;

        public PagoService(IPagoRepository pagoRepository)
        {
            _pagoRepository = pagoRepository;
        }

        public IEnumerable<Pago> ObtenerTodosLosPagos()
        {
            return _pagoRepository.ObtenerTodos();
        }

        public Pago ObtenerPagoPorId(int id)
        {
            return _pagoRepository.ObtenerPorId(id);
        }

        public IEnumerable<Pago> ObtenerPagosPorReservaId(int reservaId)
        {
            return _pagoRepository.ObtenerPorReservaId(reservaId);
        }

        public void AgregarPago(Pago pago)
        {
            _pagoRepository.Agregar(pago);
        }

        public void ActualizarPago(Pago pago)
        {
            _pagoRepository.Actualizar(pago);
        }

        public void EliminarPago(int id)
        {
            _pagoRepository.Eliminar(id);
        }
    }
}