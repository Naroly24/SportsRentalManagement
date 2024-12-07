using System.Collections.Generic;
using SportsRentalManagement.Domain.Interfaces;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Services
{
    public interface IReservaService
    {
        IEnumerable<Reserva> ObtenerTodasLasReservas();
        Reserva ObtenerReservaPorId(int id);
        void AgregarReserva(Reserva reserva);
        void ActualizarReserva(Reserva reserva);
        void EliminarReserva(int id);
        IEnumerable<Reserva> ObtenerReservasPorUsuarioId(int usuarioId);
        IEnumerable<Reserva> ObtenerReservasPorEquipoId(int equipoId);
        IEnumerable<Reserva> ObtenerReservasActivas();
    }

    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public IEnumerable<Reserva> ObtenerTodasLasReservas()
        {
            return _reservaRepository.ObtenerTodas();
        }

        public Reserva ObtenerReservaPorId(int id)
        {
            return _reservaRepository.ObtenerPorId(id);
        }

        public void AgregarReserva(Reserva reserva)
        {
            _reservaRepository.Agregar(reserva);
        }

        public void ActualizarReserva(Reserva reserva)
        {
            _reservaRepository.Actualizar(reserva);
        }

        public void EliminarReserva(int id)
        {
            _reservaRepository.Eliminar(id);
        }

        public IEnumerable<Reserva> ObtenerReservasPorUsuarioId(int usuarioId)
        {
            return _reservaRepository.ObtenerPorUsuarioId(usuarioId);
        }

        public IEnumerable<Reserva> ObtenerReservasPorEquipoId(int equipoId)
        {
            return _reservaRepository.ObtenerPorEquipoId(equipoId);
        }

        public IEnumerable<Reserva> ObtenerReservasActivas()
        {
            return _reservaRepository.ObtenerReservasActivas();
        }
    }
}