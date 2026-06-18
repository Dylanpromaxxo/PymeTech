using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.SuppliersDTOs
{
    public class SupplerSummaryDTO
    {
        public int IdProveedor { get; init; }
        public int IdTenant { get; init; }
        public string Email { get; init; } = string.Empty; 
        public string NombreContacto { get; init; } = string.Empty ;
        public string RazonSocial { get; init; } = string.Empty; 
        public bool Activo { get; init; }
    }
}
