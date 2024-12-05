using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsRentalManagement.Domain.Interfaces
{
    using SportsRentalManagement.Models;
    using System.Collections.Generic;

    public interface IReservaRepository
    {
        /// <summary>
        /// Obtiene todas las reservas.
        /// </summary>
        /// <returns>Una lista de reservas.</returns>
        IEnumerable<Reserva> ObtenerTodas();

        /// <summary>
        /// Obtiene una reserva por su ID.
        /// </summary>
        /// <param name="id">El ID de la reserva.</param>
        /// <returns>La reserva correspondiente.</returns>
        Reserva ObtenerPorId(int id);

        /// <summary>
        /// Agrega una nueva reserva.
        /// </summary>
        /// <param name="reserva">La reserva a agregar.</param>
        void Agregar(Reserva reserva);

        /// <summary>
        /// Actualiza una reserva existente.
        /// </summary>
        /// <param name="reserva">La reserva con los datos actualizados.</param>
        void Actualizar(Reserva reserva);

        /// <summary>
        /// Elimina una reserva por su ID.
        /// </summary>
        /// <param name="id">El ID de la reserva a eliminar.</param>
        void Eliminar(int id);

        /// <summary>
        /// Obtiene las reservas de un usuario específico.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <returns>Una lista de reservas asociadas al usuario.</returns>
        IEnumerable<Reserva> ObtenerPorUsuarioId(int usuarioId);

        /// <summary>
        /// Obtiene las reservas para un equipo específico.
        /// </summary>
        /// <param name="equipoId">El ID del equipo.</param>
        /// <returns>Una lista de reservas asociadas al equipo.</returns>
        IEnumerable<Reserva> ObtenerPorEquipoId(int equipoId);

        /// <summary>
        /// Obtiene las reservas activas.
        /// </summary>
        /// <returns>Una lista de reservas con estado activo.</returns>
        IEnumerable<Reserva> ObtenerReservasActivas();
    }
}

