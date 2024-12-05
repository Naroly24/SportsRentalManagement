namespace SportsRentalManagement.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public Reserva ? Reserva { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public required string MetodoPago { get; set; }
        public bool EstadoPago { get; set; }
    }
}
