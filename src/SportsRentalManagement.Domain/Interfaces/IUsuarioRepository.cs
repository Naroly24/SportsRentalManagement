using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsRentalManagement.Domain.Interfaces
{
    using SportsRentalManagement.Models;
    using System.Collections.Generic;

    public interface IUsuarioRepository
    {
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns>Una lista de usuarios.</returns>
        IEnumerable<Usuario> ObtenerTodos();

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">El ID del usuario.</param>
        /// <returns>El usuario correspondiente.</returns>
        Usuario ObtenerPorId(int id);

        /// <summary>
        /// Agrega un nuevo usuario.
        /// </summary>
        /// <param name="usuario">El usuario a agregar.</param>
        void Agregar(Usuario usuario);

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="usuario">El usuario con los datos actualizados.</param>
        void Actualizar(Usuario usuario);

        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="id">El ID del usuario a eliminar.</param>
        void Eliminar(int id);
    }
}

