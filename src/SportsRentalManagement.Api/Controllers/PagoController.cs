using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Data;
using SportsRentalManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly AppDBContext _context;

        public PagoController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Pago
        [HttpGet]
        public async Task<IActionResult> GetPagos()
        {
            var pagos = await _context.Pagos
                .Include(p => p.Reserva)
                .ToListAsync();
            return Ok(pagos);
        }

        // GET: api/Pago/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPago(int id)
        {
            var pago = await _context.Pagos
                .Include(p => p.Reserva)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pago == null)
            {
                return NotFound();
            }

            return Ok(pago);
        }

        // POST: api/Pago
        [HttpPost]
        public async Task<IActionResult> CreatePago([FromBody] Pago pago)
        {
            if (ModelState.IsValid)
            {
                pago.FechaPago = DateTime.Now;
                _context.Pagos.Add(pago);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPago), new { id = pago.Id }, pago);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Pago/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePago(int id, [FromBody] Pago pago)
        {
            if (id != pago.Id)
            {
                return BadRequest();
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
                    if (!PagoExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Pago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePago(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
