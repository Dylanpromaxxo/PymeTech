using FluentValidation;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {


            RuleFor(x => x.TipoDocumento)
                 .NotEmpty().WithMessage("El tipo de documento es obligatorio.")
                 .Must(tipo => Clientes.TiposDocumento.Validos.Contains(tipo, StringComparer.OrdinalIgnoreCase))
                 .WithMessage("Tipo de documento inválido. Valores permitidos: NIT, DPI, DNI, CE, PASAPORTE, OTRO.");

            RuleFor(x => x.NumeroDocumento)
                .NotEmpty().WithMessage("El número de documento es obligatorio.")
                .MaximumLength(50).WithMessage("El número de documento no puede superar los 50 caracteres.");

            RuleFor(x => x.RazonSocial)
                .NotEmpty().WithMessage("La razón social es obligatoria.")
                .MaximumLength(200).WithMessage("La razón social no puede superar los 200 caracteres.");

           

           

            

            

            RuleFor(x => x.TipoCliente)
                .NotEmpty().WithMessage("El tipo de cliente es obligatorio.")
                .Must(tipo => Clientes.TiposCliente.Validos.Contains(tipo, StringComparer.OrdinalIgnoreCase))
                .WithMessage("Tipo de cliente inválido. Valores permitidos: PERSONA_NATURAL, EMPRESA.");
        }
    }
}
