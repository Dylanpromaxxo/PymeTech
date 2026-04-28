using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<int>
    {
       
        public string TipoDocumento { get; init; } = string.Empty;
        public string NumeroDocumento { get; init; } = string.Empty;
        public string RazonSocial { get; init; } = string.Empty;
        public string NombreContacto { get; init; }
        public string Email { get; init; }
        public string Telefono { get; init; }
        public string Direccion { get; init; }
        public string TipoCliente { get; init; } = string.Empty;
    }
}
