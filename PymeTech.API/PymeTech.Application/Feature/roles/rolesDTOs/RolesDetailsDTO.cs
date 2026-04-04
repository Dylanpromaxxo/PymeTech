using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.rolesDTOs
{
    public record RolesDetailsDTO
    {
        
            public int IdRol { get; init; }
        public string NombreRol { get; init; } = string.Empty;
        public string Descripcion { get; init; } = string.Empty; 
            public bool Activo { get; init; }
            public List<PermissionSummaryDTO> Permisos { get; init; } = new();
        

        

    }
}
