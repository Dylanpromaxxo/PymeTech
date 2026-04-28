using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.SuppliersDTOs
{
    public record SupplerDTO
    {
        public int IdProveedor  { get; init; }
        public int IdTenant { get; init; } 
        public string Email { get; init; } 
        public string Telefono { get; init; } 
        public string Direccion { get; init; } 
        public bool Activo { get; init; } 
        public DateTime FechaCreacion { get; init; } 
        public UserCreator CreadoPor { get; init; } 

    }


    public record UserCreator 
    {


    }

}
