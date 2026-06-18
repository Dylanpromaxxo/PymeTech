using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Commands.Create
{
    public class CreateCategoryValidator: AbstractValidator<CreateCategoriCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Nombre).NotEmpty().WithMessage("El nombre no puede estar vacio");
        }
    }
}
