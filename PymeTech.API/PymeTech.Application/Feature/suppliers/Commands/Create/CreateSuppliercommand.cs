using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Commands.Create
{
    public class CreateSuppliercommand: IRequest<int>
    {
      
        public string TipoDocumento { get; init; } = string.Empty;
        public string NumeroDocumento { get; init; } = string.Empty;
        public string RazonSocial { get; init; } = string.Empty;
        public string NombreContacto { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Telefono { get; init; } = string.Empty;
        public string Direccion { get; init; } = string.Empty;
        public bool Activo { get; init; }
    

    }
}
