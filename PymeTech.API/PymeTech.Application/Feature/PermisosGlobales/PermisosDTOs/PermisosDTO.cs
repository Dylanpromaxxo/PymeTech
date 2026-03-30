using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs
{
    public record PermisosDTO
    {
        public int IdPermisos { get; init;  }
        public string Modulo { get; init; } 
        public string Accion { get; init; } 
        public string ? Descripcion { get; init; } 
    }
}
