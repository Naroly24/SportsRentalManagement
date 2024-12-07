﻿namespace SportsRentalManagement.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Correo { get; set; }
        public required string Telefono { get; set; }
        public required string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public required string DocumentoIdentidad { get; set; }

    }
}
