using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsRentalManagement.Domain.Interfaces
{
    using SportsRentalManagement.Models;
    using System.Collections.Generic;

    public interface IEquipoRepository
    {
        /// <summary>
        /// Obtiene todos los equipos.
        /// </summary>
        /// <returns>Una lista de equipos.</returns>
        IEnumerable<Equipo> ObtenerTodos();

        /// <summary>
        /// Obtiene un equipo por su ID.
        /// </summary>
        /// <param name="id">El ID del equipo.</param>
        /// <returns>El equipo correspondiente.</returns>
        Equipo ObtenerPorId(int id);

        /// <summary>
        /// Agrega un nuevo equipo.
        /// </summary>
        /// <param name="equipo">El equipo a agregar.</param>
        void Agregar(Equipo equipo);

        /// <summary>
        /// Actualiza un equipo existente.
        /// </summary>
        /// <param name="equipo">El equipo con los datos actualizados.</param>
        void Actualizar(Equipo equipo);

        /// <summary>
        /// Elimina un equipo por su ID.
        /// </summary>
        /// <param name="id">El ID del equipo a eliminar.</param>
        void Eliminar(int id);
    }
}

