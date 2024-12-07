namespace SportsRentalManagement.Models
{
    public class Facturacion
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public Reserva? Reserva { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaFactura { get; set; }
        public required string EstadoFactura { get; set; }
        public required string MetodoPago { get; set; }
        public Facturacion()
        {
            Reserva = null;
        }
    }
}
    
