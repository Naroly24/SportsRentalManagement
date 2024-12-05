using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Data;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {
        private readonly AppDBContext _context;

        public FacturacionController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Facturacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facturacion>>> GetFacturaciones()
        {
            var facturaciones = await _context.Facturaciones.ToListAsync();
            return Ok(facturaciones);  // Devuelve una lista de facturaciones en formato JSON
        }

        // GET: api/Facturacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facturacion>> GetFacturacion(int id)
        {
            var facturacion = await _context.Facturaciones.FindAsync(id);

            if (facturacion == null)
            {
                return NotFound();  // Si no se encuentra, devuelve un 404
            }

            return Ok(facturacion);  // Devuelve la facturación en formato JSON
        }

        // POST: api/Facturacion
        [HttpPost]
        public async Task<ActionResult<Facturacion>> PostFacturacion(Facturacion facturacion)
        {
            if (facturacion == null)
            {
                return BadRequest();  // Devuelve un 400 si los datos enviados son nulos
            }

            _context.Facturaciones.Add(facturacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFacturacion), new { id = facturacion.Id }, facturacion);
            // Devuelve el objeto creado con el código de estado 201 y la URL para obtenerlo
        }

        // PUT: api/Facturacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturacion(int id, Facturacion facturacion)
        {
            if (id != facturacion.Id)
            {
                return BadRequest();  // Si los IDs no coinciden, devuelve un 400
            }

            _context.Entry(facturacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturacionExists(id))
                {
                    return NotFound();  // Si no se encuentra la facturación, devuelve un 404
                }
                throw;
            }

            return NoContent();  // Devuelve un código 204 si la actualización fue exitosa
        }

        // DELETE: api/Facturacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturacion(int id)
        {
            var facturacion = await _context.Facturaciones.FindAsync(id);
            if (facturacion == null)
            {
                return NotFound();  // Si no se encuentra la facturación, devuelve un 404
            }

            _context.Facturaciones.Remove(facturacion);
            await _context.SaveChangesAsync();

            return NoContent();  // Devuelve un código 204 si la eliminación fue exitosa
        }

        private bool FacturacionExists(int id)
        {
            return _context.Facturaciones.Any(e => e.Id == id);
        }
    }
}
