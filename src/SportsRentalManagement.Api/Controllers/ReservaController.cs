using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Models;
using SportsRentalManagement.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsRentalManagement.Controllers
{
    public class ReservaController : Controller
    {
        private readonly AppDBContext _context;

        public ReservaController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .ToListAsync(); // Obtener las reservas con usuarios y equipos asociados
            return View(reservas);
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .FirstOrDefaultAsync(r => r.Id == id); // Obtener la reserva por ID

            if (reserva == null)
            {
                return View("Error");
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            // Asumiendo que tienes acceso a las tablas de usuarios y equipos en el contexto
            ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre"); // Ajusta según la estructura de tu modelo Usuario
            ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre");   // Ajusta según la estructura de tu modelo Equipo
            return View();
        }

        // POST: Reserva/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                // Validar que la fecha de inicio sea menor que la fecha de fin
                if (reserva.FechaInicio >= reserva.FechaFin)
                {
                    ModelState.AddModelError("", "La fecha de inicio debe ser menor que la fecha de fin.");
                    ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre", reserva.UsuarioId);
                    ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre", reserva.EquipoId);
                    return View(reserva);
                }

                // Calcular el total de la reserva (esto se puede ajustar dependiendo de la lógica de negocio)
                var equipo = await _context.Equipos.FindAsync(reserva.EquipoId);
                if (equipo != null)
                {
                    // Calcular el total de la reserva basado en los días de la reserva
                    var diasReserva = (reserva.FechaFin - reserva.FechaInicio).Days;
                    if (diasReserva > 0) // Asegurarse de que la duración es positiva
                    {
                        reserva.TotalReserva = equipo.PrecioPorDia * diasReserva; // Ajusta el cálculo según la propiedad PrecioPorDia del equipo
                    }
                    else
                    {
                        ModelState.AddModelError("", "La duración de la reserva debe ser mayor a cero días.");
                        ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre", reserva.UsuarioId);
                        ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre", reserva.EquipoId);
                        return View(reserva);
                    }
                }

                // Guardar la reserva en la base de datos
                _context.Add(reserva);
                await _context.SaveChangesAsync();

                // Redirigir a la vista Index para mostrar todas las reservas
                return RedirectToAction(nameof(Index));
            }

            // Si el modelo no es válido, recargar la vista con los datos actuales
            ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre", reserva.UsuarioId);
            ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre", reserva.EquipoId);
            return View(reserva);
        }


        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id); // Asegúrate de que 'Reservas' sea el DbSet correcto.
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva); // Pasar el objeto 'reserva' a la vista.
        }


        // POST: Reserva/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Calcular el TotalReserva basándose en la duración
                    var equipo = await _context.Equipos.FindAsync(reserva.EquipoId);
                    if (equipo != null)
                    {
                        // Calcular la duración de la reserva en días
                        var duration = (reserva.FechaFin - reserva.FechaInicio).Days;
                        // Asignar el TotalReserva (puedes ajustar la fórmula según tu lógica)
                        reserva.TotalReserva = equipo.PrecioPorDia * duration;
                    }

                    // Actualizar la reserva en la base de datos
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }

            // En caso de error, inicializar los ViewBag de nuevo
            ViewBag.Usuarios = new SelectList(await _context.Usuarios.ToListAsync(), "Id", "Nombre", reserva.UsuarioId);
            ViewBag.Equipos = new SelectList(await _context.Equipos.ToListAsync(), "Id", "Nombre", reserva.EquipoId);

            return View(reserva);
        }



        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .FirstOrDefaultAsync(r => r.Id == id); // Obtener la reserva por ID

            if (reserva == null)
            {
                return View("Error");
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null) // Verifica que la reserva no sea nula
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
