using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Commands.ChangeStatusRol
{
    public  class ChangeStatusRolValidator : AbstractValidator<ChangeStatusRolCommand>
    {
        public ChangeStatusRolValidator()
        {
            RuleFor(r => r.IdRol).GreaterThan(0).WithMessage("El id no debe ser menor a 0 "); 
        }
    }
}
