using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Commands.Update
{
    public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.IdCategory).GreaterThan(0).WithMessage("El Id de la categoria debe ser mayor a 0");
            RuleFor(c => c.Nombre).NotEmpty().WithMessage("El nombre no puede estar vacio");
            

        }
    }
}
