using FluentValidation;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Validators
{
    public class FacturacionValidator : AbstractValidator<Facturacion>
    {
        public FacturacionValidator()
        {
            RuleFor(f => f.Total)
                .GreaterThan(0).WithMessage("El total de la factura debe ser mayor que 0.");

            RuleFor(f => f.FechaFactura)
                .NotEmpty().WithMessage("La fecha de la factura es obligatoria.");

            RuleFor(f => f.EstadoFactura)
                .NotEmpty().WithMessage("El estado de la factura es obligatorio.")
                .Length(2, 50).WithMessage("El estado de la factura debe tener entre 2 y 50 caracteres.");

            RuleFor(f => f.MetodoPago)
                .NotEmpty().WithMessage("El método de pago es obligatorio.")
                .Length(2, 50).WithMessage("El método de pago debe tener entre 2 y 50 caracteres.");
        }
    }
}
