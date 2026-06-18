using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.SuppliersDTOs
{
    public record SupplerDTO
    {
        public int IdProveedor  { get; init; }
        public int IdTenant { get; init; } 
        public string TipoDocumento { get; init; } = string.Empty;
        public string NumeroDocumento { get; init; } = string.Empty;
        public string RazonSocial { get; init; } = string.Empty;
        public string NombreContacto { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Telefono { get; init; } = string.Empty;
        public string Direccion { get; init; } = string.Empty;
        public bool Activo { get; init; } 
        public DateTime FechaCreacion { get; init; } 

    }



}
