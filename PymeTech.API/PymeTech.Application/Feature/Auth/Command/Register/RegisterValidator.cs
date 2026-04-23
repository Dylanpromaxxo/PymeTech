using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Auth.Command.Register
{
    public class RegisterValidator: AbstractValidator<RegisterCommand>

    {
        public RegisterValidator()
        {
            // datos de la empresa
            RuleFor(x => x.NombreEmpresa)
                .NotEmpty().WithMessage("El nombre de la empresa es obligatorio")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres");

            RuleFor(x => x.TelefonoEmpresa)
                .NotEmpty().WithMessage("El teléfono es obligatorio")
                .MaximumLength(20).WithMessage("Máximo 20 caracteres");

            // datos del usuario
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("El email no tiene formato válido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El password es obligatorio")
                .MinimumLength(8).WithMessage("El password debe tener mínimo 8 caracteres")
                .Matches("[A-Z]").WithMessage("Debe tener al menos una mayúscula")
                .Matches("[0-9]").WithMessage("Debe tener al menos un número");

        //confirmacion 
            RuleFor(x => x.ConfirmarPassword)
                .Equal(x => x.Password).WithMessage("Los passwords no coinciden");
        }
    }
}
