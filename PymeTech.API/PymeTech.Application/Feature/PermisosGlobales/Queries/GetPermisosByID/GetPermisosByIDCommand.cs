using MediatR;
using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Queries.GetPermisosByID
{
    public record GetPermisosByIDCommand : IRequest<PermisosDTO>
    {
        public int IdPermisos { get; init ; } 

    }
}
