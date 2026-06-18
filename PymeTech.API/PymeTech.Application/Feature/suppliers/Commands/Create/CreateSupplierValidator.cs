using FluentValidation;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Commands.Create
{
    public class CreateSupplierValidator: AbstractValidator<CreateSuppliercommand>
    {
        public CreateSupplierValidator()
        {
            
            RuleFor(c => c.TipoDocumento).NotEmpty()
                .Must(tipo=> Proveedores.TiposDocumento.Validos.Contains(tipo  , StringComparer.OrdinalIgnoreCase))
                .WithMessage("TipoDocumento debe ser uno de los siguientes valores: " + string.Join(", ", Proveedores.TiposDocumento.Validos));
            RuleFor(c => c.NumeroDocumento).NotEmpty().WithMessage("NumeroDocumento es requerido"); 
            RuleFor(c => c.RazonSocial).NotEmpty().WithMessage("RazonSocial es requerido");
            RuleFor(c => c.NombreContacto).MaximumLength(80).WithMessage("NombreContacto no puede superar los 80 caracteres");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Email debe ser un correo electrónico válido").MaximumLength(150).WithMessage("Email no puede superar los 150 caracteres");
            RuleFor(c => c.Telefono).MaximumLength(20);
            RuleFor(c => c.Direccion).MaximumLength(200);






        }
    }
}
