using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.rolesDTOs
{
    public  class PermissionSummaryDTO
    {
        
            public int IdPermiso { get; init; }
            public string Modulo { get; init; } = string.Empty;
            public string? Accion { get; init; }
        
    }
}
