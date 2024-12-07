namespace SportsRentalManagement.Dtos
{
    public class ReservaDto
    {
        public int UsuarioId { get; set; }
        public int EquipoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string EstadoReserva { get; set; }
        public decimal TotalReserva { get; set; }
    }
}
