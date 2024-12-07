using System.Collections.Generic;
using SportsRentalManagement.Domain.Interfaces;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> ObtenerTodosLosUsuarios();
        Usuario ObtenerUsuarioPorId(int id);
        void AgregarUsuario(Usuario usuario);
        void ActualizarUsuario(Usuario usuario);
        void EliminarUsuario(int id);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
        {
            return _usuarioRepository.ObtenerTodos();
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return _usuarioRepository.ObtenerPorId(id);
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _usuarioRepository.Agregar(usuario);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            _usuarioRepository.Actualizar(usuario);
        }

        public void EliminarUsuario(int id)
        {
            _usuarioRepository.Eliminar(id);
        }
    }
}