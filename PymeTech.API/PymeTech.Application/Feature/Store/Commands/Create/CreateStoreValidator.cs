using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Store.Commands.Create
{
    public class CreateStoreValidator:AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreValidator()
        {
            RuleFor(s => s.Nombre).NotEmpty().WithMessage("El nombre no puede estar vacio "); 
           
        }
    }
}
