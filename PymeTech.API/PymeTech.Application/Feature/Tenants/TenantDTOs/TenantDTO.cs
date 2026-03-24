using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Tenants.TenantDTOs
{
    public record TenantDTO
    {
        public int IdTenant { get; init; }
        public string Nombre { get; init; }
        public string Email { get; init; }
        public string Telefono { get; init; }
        public string PlanSuscripcion { get; init; }
        public DateTime FechaCreacion { get; init; }
        public  bool Activo { get; init; }

    }
}
