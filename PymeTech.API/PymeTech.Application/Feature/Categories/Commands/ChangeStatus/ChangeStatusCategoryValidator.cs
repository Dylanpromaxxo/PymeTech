using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Commands.ChangeStatus
{
    public class ChangeStatusCategoryValidator : AbstractValidator<ChangeStatusCategoryCommad>
    {
        public ChangeStatusCategoryValidator()
        {
            RuleFor(c => c.IdCategory).GreaterThan(0).WithMessage("El Id de la categoria debe ser mayor a 0");
        }
    }
}
