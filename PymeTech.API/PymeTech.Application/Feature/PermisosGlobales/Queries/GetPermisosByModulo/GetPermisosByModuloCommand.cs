using MediatR;
using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Queries.GetPermisosByModulo
{
    public record  GetPermisosByModuloCommand: IRequest<List<PermisosDTO>>
    {
        public string Modulo { get; init; }
        public string ? Accion { get; init; } 

    }
}
