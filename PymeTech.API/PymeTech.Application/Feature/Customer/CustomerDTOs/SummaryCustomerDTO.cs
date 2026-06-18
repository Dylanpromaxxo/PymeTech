using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.CustomerDTOs
{
    public record SummaryCustomerDTO  
    {
        public int idCliente { get; init; } 
        public string TipoDocumento { get; init; } = string.Empty;
        public string NombreContacto { get; init; } 
        public string Email { get; init; }
        public string Telefono { get; init; }
        public bool Activo { get; init; } 
        public DateTime FechaCreacion { get; init; } 






    }
}
