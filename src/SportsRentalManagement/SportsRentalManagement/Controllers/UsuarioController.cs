using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Models;
using SportsRentalManagement.Data;

namespace SportsRentalManagement.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDBContext _context;  

        public UsuarioController(AppDBContext context)
        {
            _context = context;
        }
        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync(); 
            return View(usuarios);
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id); 
            if (usuario == null)
            {
                return View("Error");
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);  // Agregar el nuevo usuario a la base de datos
                await _context.SaveChangesAsync();  // Guardar los cambios
                return RedirectToAction(nameof(Index));  // Redirigir a la lista de usuarios
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);  // Buscar el usuario por ID
            if (usuario == null)
            {
                return View("Error");
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);  // Actualizar el usuario en la base de datos
                    await _context.SaveChangesAsync();  // Guardar los cambios
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return View("Error");
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));  // Redirigir a la lista de usuarios
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);  // Buscar el usuario por ID
            if (usuario == null)
            {
                return View("Error");
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);  // Buscar el usuario por ID
            _context.Usuarios.Remove(usuario);  // Eliminar el usuario de la base de datos
            await _context.SaveChangesAsync();  // Guardar los cambios
            return RedirectToAction(nameof(Index));  // Redirigir a la lista de usuarios
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);  // Verificar si el usuario existe
        }
    }
}

