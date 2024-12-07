using FluentValidation;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Validators
{
    public class EquipoValidator : AbstractValidator<Equipo>
    {
        public EquipoValidator()
        {
            RuleFor(e => e.Nombre)
                .NotEmpty().WithMessage("El nombre del equipo es obligatorio.")
                .Length(2, 100).WithMessage("El nombre del equipo debe tener entre 2 y 100 caracteres.");

            RuleFor(e => e.Descripcion)
                .NotEmpty().WithMessage("La descripción del equipo es obligatoria.")
                .Length(5, 250).WithMessage("La descripción debe tener entre 5 y 250 caracteres.");

            RuleFor(e => e.CantidadDisponible)
                .GreaterThanOrEqualTo(0).WithMessage("La cantidad disponible no puede ser menor que 0.");

            RuleFor(e => e.PrecioPorDia)
                .GreaterThan(0).WithMessage("El precio por día debe ser mayor que 0.");

            RuleFor(e => e.TipoEquipo)
                .NotEmpty().WithMessage("El tipo de equipo es obligatorio.")
                .Length(2, 50).WithMessage("El tipo de equipo debe tener entre 2 y 50 caracteres.");

            RuleFor(e => e.Marca)
                .NotEmpty().WithMessage("La marca del equipo es obligatoria.")
                .Length(2, 50).WithMessage("La marca debe tener entre 2 y 50 caracteres.");

            RuleFor(e => e.FechaIngreso)
                .NotEmpty().WithMessage("La fecha de ingreso es obligatoria.");

            RuleFor(e => e.Estado)
                .NotNull().WithMessage("El estado del equipo no puede ser nulo.");
        }
    }
}
