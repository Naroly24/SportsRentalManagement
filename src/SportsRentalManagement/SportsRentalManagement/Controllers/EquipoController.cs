using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Data;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Controllers
{
    public class EquipoController : Controller
    {
        private readonly AppDBContext _appDbContext;

        public EquipoController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Equipo> lista = await _appDbContext.Equipos.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                await _appDbContext.Equipos.AddAsync(equipo);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }
            return View(equipo);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int Id)
        {
            Equipo equipo = await _appDbContext.Equipos.FirstAsync(e => e.Id == Id);
            return View(equipo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Equipos.Update(equipo);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }
            return View(equipo);
        }

        [HttpGet]
        public async Task<IActionResult> Detalles(int Id)
        {
            Equipo equipo = await _appDbContext.Equipos.FirstAsync(e => e.Id == Id);
            return View(equipo);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int Id)
        {
            Equipo equipo = await _appDbContext.Equipos.FirstAsync(e => e.Id == Id);
            return View(equipo);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarConfirmado(int Id)
        {
            Equipo equipo = await _appDbContext.Equipos.FirstAsync(e => e.Id == Id);
            _appDbContext.Equipos.Remove(equipo);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> Actualizar(int Id)
        {
            Equipo equipo = await _appDbContext.Equipos.FirstAsync(e => e.Id == Id);
            return View(equipo);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _appDbContext.Equipos.Update(equipo);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Lista));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "No se pudo actualizar el equipo. Intente nuevamente.");
                    return View(equipo);
                }
            }
            return View(equipo);
        }
    }
}
