namespace SportsRentalManagement.Dtos
{
    public class EquipoDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal PrecioPorDia { get; set; }
        public string TipoEquipo { get; set; }
        public string Marca { get; set; }
        public bool Estado { get; set; }
    }
}
