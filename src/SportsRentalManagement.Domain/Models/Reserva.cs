namespace SportsRentalManagement.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int EquipoId { get; set; }
        public Equipo? Equipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public required string EstadoReserva { get; set; }
        public decimal TotalReserva { get; set; }
    }
}