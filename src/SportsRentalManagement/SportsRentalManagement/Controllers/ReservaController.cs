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
                .ToListAsync();
            return View(reservas);
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reserva == null)
            {
                return View("Error");
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre"); // Mostrar los usuarios
            ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre"); // Mostrar los equipos
            return View();
        }

        // POST: Reserva/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                if (reserva.FechaInicio >= reserva.FechaFin)
                {
                    ModelState.AddModelError("", "La fecha de inicio debe ser menor que la fecha de fin.");
                    ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre", reserva.UsuarioId);
                    ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre", reserva.EquipoId);
                    return View(reserva);
                }

                var equipo = await _context.Equipos.FindAsync(reserva.EquipoId);
                if (equipo != null)
                {
                    var diasReserva = (reserva.FechaFin - reserva.FechaInicio).Days;
                    if (diasReserva > 0)
                    {
                        reserva.TotalReserva = equipo.PrecioPorDia * diasReserva;
                    }
                    else
                    {
                        ModelState.AddModelError("", "La duración de la reserva debe ser mayor a cero días.");
                        ViewBag.Usuarios = new SelectList(_context.Usuarios, "Id", "Nombre", reserva.UsuarioId);
                        ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre", reserva.EquipoId);
                        return View(reserva);
                    }
                }

                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

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

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
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
                    var equipo = await _context.Equipos.FindAsync(reserva.EquipoId);
                    if (equipo != null)
                    {
                        var duration = (reserva.FechaFin - reserva.FechaInicio).Days;
                        reserva.TotalReserva = equipo.PrecioPorDia * duration;
                    }

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
                .FirstOrDefaultAsync(r => r.Id == id);

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
            if (reserva != null)
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
