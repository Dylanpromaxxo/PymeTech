using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Auth.Command.Login
{
    public class LoginValidator:AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
          .NotEmpty().WithMessage("El email es obligatorio")
          .EmailAddress().WithMessage("El email no tiene formato válido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El password es obligatorio");
        }
    }
}
