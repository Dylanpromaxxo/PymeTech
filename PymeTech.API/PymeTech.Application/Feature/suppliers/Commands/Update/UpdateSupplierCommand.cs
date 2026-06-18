using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Commands.Update
{
    public class UpdateSupplierCommand : IRequest<bool>
    {
        public int IdProveedor { get; init; }
        public string TipoDocumento { get; init; } = string.Empty;
        public string NumeroDocumento { get; init; } = string.Empty;
        public string RazonSocial { get; init; } = string.Empty;
        public string NombreContacto { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Telefono { get; init; } = string.Empty;
        public string Direccion { get; init; } = string.Empty;
    }
}
