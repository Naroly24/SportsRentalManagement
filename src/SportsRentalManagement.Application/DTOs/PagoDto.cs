namespace SportsRentalManagement.Dtos
{
    public class PagoDto
    {
        public int ReservaId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public bool EstadoPago { get; set; }
    }
}
