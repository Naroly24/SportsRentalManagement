using System.Collections.Generic;
using System.Threading.Tasks;
using SportsRentalManagement.Contract.Repositories;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObtenerTodosLosUsuarios();
        Task<Usuario> ObtenerUsuarioPorId(int id);
        Task AgregarUsuario(Usuario usuario);
        Task ActualizarUsuario(Usuario usuario);
        Task EliminarUsuario(int id);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosLosUsuarios()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task AgregarUsuario(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task ActualizarUsuario(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task EliminarUsuario(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}