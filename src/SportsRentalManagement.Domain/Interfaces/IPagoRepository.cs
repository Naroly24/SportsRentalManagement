using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsRentalManagement.Domain.Interfaces
{
    using SportsRentalManagement.Models;
    using System.Collections.Generic;

    public interface IPagoRepository
    {
        /// <summary>
        /// Obtiene todos los pagos.
        /// </summary>
        /// <returns>Una lista de pagos.</returns>
        IEnumerable<Pago> ObtenerTodos();

        /// <summary>
        /// Obtiene un pago por su ID.
        /// </summary>
        /// <param name="id">El ID del pago.</param>
        /// <returns>El pago correspondiente.</returns>
        Pago ObtenerPorId(int id);

        /// <summary>
        /// Obtiene los pagos relacionados con una reserva específica.
        /// </summary>
        /// <param name="reservaId">El ID de la reserva.</param>
        /// <returns>Una lista de pagos para esa reserva.</returns>
        IEnumerable<Pago> ObtenerPorReservaId(int reservaId);

        /// <summary>
        /// Agrega un nuevo pago.
        /// </summary>
        /// <param name="pago">El pago a agregar.</param>
        void Agregar(Pago pago);

        /// <summary>
        /// Actualiza un pago existente.
        /// </summary>
        /// <param name="pago">El pago con los datos actualizados.</param>
        void Actualizar(Pago pago);

        /// <summary>
        /// Elimina un pago por su ID.
        /// </summary>
        /// <param name="id">El ID del pago a eliminar.</param>
        void Eliminar(int id);
    }
}

