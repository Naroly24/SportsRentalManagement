using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Data;
using SportsRentalManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UsuarioController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);  // Retornar la lista de usuarios en formato JSON
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();  // Si no se encuentra el usuario, retornar 404
            }

            return Ok(usuario);  // Retornar el usuario en formato JSON
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuario no puede ser nulo");  // Validar si el usuario es nulo
            }

            if (ModelState.IsValid)
            {
                _context.Add(usuario);  // Agregar el nuevo usuario a la base de datos
                await _context.SaveChangesAsync();  // Guardar los cambios
                return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);  // Retornar 201 con el nuevo recurso
            }

            return BadRequest(ModelState);  // Si el modelo no es válido, retornar 400 con el error
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest("ID de usuario no coincide");  // Validar que el ID coincida
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);  // Actualizar el usuario en la base de datos
                    await _context.SaveChangesAsync();  // Guardar los cambios
                    return NoContent();  // Retornar 204 (sin contenido) si la actualización fue exitosa
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(id))
                    {
                        return NotFound();  // Si no existe el usuario, retornar 404
                    }
                    throw;
                }
            }

            return BadRequest(ModelState);  // Si el modelo no es válido, retornar 400 con el error
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();  // Si no se encuentra el usuario, retornar 404
            }

            _context.Usuarios.Remove(usuario);  // Eliminar el usuario de la base de datos
            await _context.SaveChangesAsync();  // Guardar los cambios
            return NoContent();  // Retornar 204 (sin contenido) después de eliminar el usuario
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);  // Verificar si el usuario existe
        }
    }
}
