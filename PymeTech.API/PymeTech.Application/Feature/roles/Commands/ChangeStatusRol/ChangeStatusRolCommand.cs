using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.roles.Commands.ChangeStatusRol
{
    public  record  ChangeStatusRolCommand :IRequest<bool>
    {
        public int IdRol { get; init;  }
    }
}
