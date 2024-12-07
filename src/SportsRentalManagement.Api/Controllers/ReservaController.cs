using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Models;
using SportsRentalManagement.Data;

namespace SportsRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Ruta base: api/reserva
    public class ReservaController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ReservaController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/reserva
        [HttpGet]
        public async Task<IActionResult> GetReservas()
        {
            var reservas = await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .ToListAsync();
            return Ok(reservas);
        }

        // GET: api/reserva/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReserva(int id)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Equipo)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reserva == null)
            {
                return NotFound(new { Message = "Reserva no encontrada" });
            }

            return Ok(reserva);
        }

        // POST: api/reserva
        [HttpPost]
        public async Task<IActionResult> CreateReserva([FromBody] Reserva reserva)
        {
            if (reserva.FechaInicio >= reserva.FechaFin)
            {
                return BadRequest(new { Message = "La fecha de inicio debe ser menor que la fecha de fin." });
            }

            var equipo = await _context.Equipos.FindAsync(reserva.EquipoId);
            if (equipo == null)
            {
                return BadRequest(new { Message = "Equipo no encontrado." });
            }

            var diasReserva = (reserva.FechaFin - reserva.FechaInicio).Days;
            reserva.TotalReserva = equipo.PrecioPorDia * diasReserva;

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reserva);
        }

        // PUT: api/reserva/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReserva(int id, [FromBody] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return BadRequest(new { Message = "ID no coincide con el de la reserva." });
            }

            var equipo = await _context.Equipos.FindAsync(reserva.EquipoId);
            if (equipo == null)
            {
                return BadRequest(new { Message = "Equipo no encontrado." });
            }

            reserva.TotalReserva = (reserva.FechaFin - reserva.FechaInicio).Days * equipo.PrecioPorDia;

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Reservas.Any(e => e.Id == id))
                {
                    return NotFound(new { Message = "Reserva no encontrada." });
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/reserva/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound(new { Message = "Reserva no encontrada." });
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
