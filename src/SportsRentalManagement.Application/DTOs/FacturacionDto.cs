namespace SportsRentalManagement.Dtos
{
    public class FacturacionDto
    {
        public int ReservaId { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaFactura { get; set; }
        public string EstadoFactura { get; set; }
        public string MetodoPago { get; set; }
    }
}
