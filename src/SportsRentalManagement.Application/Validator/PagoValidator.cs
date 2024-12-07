using FluentValidation;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Validators
{
    public class PagoValidator : AbstractValidator<Pago>
    {
        public PagoValidator()
        {
            RuleFor(p => p.Monto)
                .GreaterThan(0).WithMessage("El monto del pago debe ser mayor que 0.");

            RuleFor(p => p.FechaPago)
                .NotEmpty().WithMessage("La fecha de pago es obligatoria.");

            RuleFor(p => p.MetodoPago)
                .NotEmpty().WithMessage("El método de pago es obligatorio.")
                .Length(2, 50).WithMessage("El método de pago debe tener entre 2 y 50 caracteres.");

            RuleFor(p => p.EstadoPago)
                .NotNull().WithMessage("El estado del pago no puede ser nulo.");
        }
    }
}
