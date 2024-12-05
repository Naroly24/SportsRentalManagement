using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsRentalManagement.Domain.Interfaces
{
    using SportsRentalManagement.Models;
    using System.Collections.Generic;

    public interface IFacturacionRepository
    {
        /// <summary>
        /// Obtiene todas las facturas.
        /// </summary>
        /// <returns>Una lista de facturas.</returns>
        IEnumerable<Facturacion> ObtenerTodas();

        /// <summary>
        /// Obtiene una factura específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la factura.</param>
        /// <returns>La factura correspondiente.</returns>
        Facturacion ObtenerPorId(int id);

        /// <summary>
        /// Agrega una nueva factura.
        /// </summary>
        /// <param name="factura">La factura a agregar.</param>
        void Agregar(Facturacion factura);

        /// <summary>
        /// Actualiza los datos de una factura existente.
        /// </summary>
        /// <param name="factura">La factura actualizada.</param>
        void Actualizar(Facturacion factura);

        /// <summary>
        /// Elimina una factura por su ID.
        /// </summary>
        /// <param name="id">El ID de la factura a eliminar.</param>
        void Eliminar(int id);

        /// <summary>
        /// Obtiene las facturas por el estado de la factura.
        /// </summary>
        /// <param name="estadoFactura">El estado de la factura.</param>
        /// <returns>Una lista de facturas con el estado especificado.</returns>
        IEnumerable<Facturacion> ObtenerPorEstado(string estadoFactura);

        /// <summary>
        /// Obtiene las facturas dentro de un rango de fechas.
        /// </summary>
        /// <param name="fechaInicio">La fecha de inicio.</param>
        /// <param name="fechaFin">La fecha de fin.</param>
        /// <returns>Una lista de facturas dentro del rango.</returns>
        IEnumerable<Facturacion> ObtenerPorRangoFechas(DateTime fechaInicio, DateTime fechaFin);
    }
}

