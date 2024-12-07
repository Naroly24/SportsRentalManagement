using FluentValidation;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Validators
{
    public class ReservaValidator : AbstractValidator<Reserva>
    {
        public ReservaValidator()
        {
            RuleFor(r => r.FechaInicio)
                .NotEmpty().WithMessage("La fecha de inicio de la reserva es obligatoria.");

            RuleFor(r => r.FechaFin)
                .NotEmpty().WithMessage("La fecha de fin de la reserva es obligatoria.")
                .GreaterThan(r => r.FechaInicio).WithMessage("La fecha de fin debe ser posterior a la fecha de inicio.");

            RuleFor(r => r.EstadoReserva)
                .NotEmpty().WithMessage("El estado de la reserva es obligatorio.")
                .Length(2, 50).WithMessage("El estado de la reserva debe tener entre 2 y 50 caracteres.");

            RuleFor(r => r.TotalReserva)
                .GreaterThan(0).WithMessage("El total de la reserva debe ser mayor que 0.");
        }
    }
}
