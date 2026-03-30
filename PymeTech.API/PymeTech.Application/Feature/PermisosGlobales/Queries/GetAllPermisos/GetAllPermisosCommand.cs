using MediatR;
using PymeTech.Application.Feature.PermisosGlobales.PermisosDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Queries.GetAllPermisos
{
    public class GetAllPermisosCommand: IRequest<List<PermisosDTO>>
    {
    }
}
