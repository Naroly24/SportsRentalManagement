// Controllers/PagoController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Data;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Controllers
{
    public class PagoController : Controller
    {
        private readonly AppDBContext _context;

        public PagoController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Pago
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pagos
                .Include(p => p.Reserva)
                .ToListAsync());
        }

        // GET: Pago/Create
        public IActionResult Create()
        {
            ViewBag.Reservas = new SelectList(_context.Reservas, "Id", "Id");
            ViewBag.MetodosPago = new List<string>
            {
                "Tarjeta de Crédito",
                "Tarjeta de Débito",
                "Transferencia Bancaria",
                "Efectivo",
                "PayPal"
            };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pago pago)
        {
            if (ModelState.IsValid)
            {
                pago.FechaPago = DateTime.Now;
                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Reservas = new SelectList(_context.Reservas, "Id", "Id", pago.ReservaId);
            ViewBag.MetodosPago = new List<string>
            {
                "Tarjeta de Crédito",
                "Tarjeta de Débito",
                "Transferencia Bancaria",
                "Efectivo",
                "PayPal"
            };
            return View(pago);
        }

        // GET: Pago/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            ViewBag.Reservas = new SelectList(_context.Reservas, "Id", "Id", pago.ReservaId);
            ViewBag.MetodosPago = new List<string>
            {
                "Tarjeta de Crédito",
                "Tarjeta de Débito",
                "Transferencia Bancaria",
                "Efectivo",
                "PayPal"
            };
            return View(pago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pago pago)
        {
            if (id != pago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Reservas = new SelectList(_context.Reservas, "Id", "Id", pago.ReservaId);
            ViewBag.MetodosPago = new List<string>
            {
                "Tarjeta de Crédito",
                "Tarjeta de Débito",
                "Transferencia Bancaria",
                "Efectivo",
                "PayPal"
            };
            return View(pago);
        }

        // GET: Pago/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Reserva)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
        // GET: Pago/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Reserva)
                    .ThenInclude(r => r.Usuario)
                .Include(p => p.Reserva)
                    .ThenInclude(r => r.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

    }
}
