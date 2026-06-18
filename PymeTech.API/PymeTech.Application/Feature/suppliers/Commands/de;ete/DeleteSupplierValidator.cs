using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Commands.de_ete
{
    public class DeleteSupplierValidator : AbstractValidator<DeleteSupplierCommad>
    {
        public DeleteSupplierValidator()
        {
            RuleFor(c => c.idProveedor).GreaterThan(0).WithMessage("El ID del proveedor no puede estar vacío");
        }
    }
}
