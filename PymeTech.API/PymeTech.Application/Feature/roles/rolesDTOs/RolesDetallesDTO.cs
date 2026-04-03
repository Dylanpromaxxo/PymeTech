using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.rolesDTOs
{
    public record RolesDetallesDTO
    {
        public record RolDetalleDto
        {
            public int IdRol { get; init; }
            public string NombreRol { get; init; }
            public string Descripcion { get; init; }
            public bool Activo { get; init; }
            public List<PermisoResumenDto> Permisos { get; init; } = new();
        }

        public record PermisoResumenDto
        {
            public int IdPermiso { get; init; }
            public string Modulo { get; init; }
            public string Accion { get; init; }
        }

    }
}
