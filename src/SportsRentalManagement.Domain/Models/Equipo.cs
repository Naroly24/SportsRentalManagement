namespace SportsRentalManagement.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal PrecioPorDia { get; set; }
        public required string TipoEquipo { get; set; }
        public required string Marca { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

    }
}
