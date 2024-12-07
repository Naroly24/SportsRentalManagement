using FluentValidation;
using SportsRentalManagement.Models;

namespace SportsRentalManagement.Application.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Nombre)
                .NotEmpty().WithMessage("El nombre del usuario es obligatorio.")
                .Length(2, 100).WithMessage("El nombre debe tener entre 2 y 100 caracteres.");

            RuleFor(u => u.Correo)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El correo electrónico no tiene un formato válido.");

            RuleFor(u => u.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .Matches(@"^\d{9}$").WithMessage("El teléfono debe tener 9 dígitos.");

            RuleFor(u => u.Direccion)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .Length(5, 250).WithMessage("La dirección debe tener entre 5 y 250 caracteres.");

            RuleFor(u => u.FechaRegistro)
                .NotEmpty().WithMessage("La fecha de registro es obligatoria.");

            RuleFor(u => u.DocumentoIdentidad)
                .NotEmpty().WithMessage("El documento de identidad es obligatorio.")
                .Length(8, 12).WithMessage("El documento de identidad debe tener entre 8 y 12 caracteres.");
        }
    }
}
