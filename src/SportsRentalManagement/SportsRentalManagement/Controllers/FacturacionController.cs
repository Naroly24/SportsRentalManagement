using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Models;
using SportsRentalManagement.Data;

namespace SportsRentalManagement.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly AppDBContext _context;

        public FacturacionController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Facturacion
        public async Task<IActionResult> Index()
        {
            var facturacion = await _context.Facturaciones.ToListAsync();
            return View(facturacion);
        }

        // GET: Facturacion/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var facturacion = await _context.Facturaciones.FindAsync(id);
            if (facturacion == null)
            {
                return View("Error");
            }
            return View(facturacion);
        }

        // GET: Facturacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facturacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Facturacion facturacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facturacion);
        }

        // GET: Facturacion/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var facturacion = await _context.Facturaciones.FindAsync(id);
            if (facturacion == null)
            {
                return View("Error");
            }
            return View(facturacion);
        }

        // POST: Facturacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Facturacion facturacion)
        {
            if (id != facturacion.Id)
            {
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturacionExists(facturacion.Id))
                    {
                        return View("Error");
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(facturacion);
        }

        // GET: Facturacion/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var facturacion = await _context.Facturaciones.FindAsync(id);
            if (facturacion == null)
            {
                return View("Error");
            }
            return View(facturacion);
        }

        // POST: Facturacion/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturacion = await _context.Facturaciones.FindAsync(id);
            if (facturacion != null)
            {
                _context.Facturaciones.Remove(facturacion);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FacturacionExists(int id)
        {
            return _context.Facturaciones.Any(e => e.Id == id);
        }
    }
}
