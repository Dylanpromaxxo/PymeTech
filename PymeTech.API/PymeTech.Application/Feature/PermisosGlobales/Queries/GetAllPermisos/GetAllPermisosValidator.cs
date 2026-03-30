using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.PermisosGlobales.Queries.GetAllPermisos
{
    public  class GetAllPermisosValidator :AbstractValidator<GetAllPermisosCommand>
    {
        public GetAllPermisosValidator()
        {
            
        }
    }
}
