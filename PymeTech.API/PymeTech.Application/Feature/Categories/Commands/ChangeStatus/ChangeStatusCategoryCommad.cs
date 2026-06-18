using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Commands.ChangeStatus
{
    public  class ChangeStatusCategoryCommad: IRequest<Unit> 
    {
        public int IdCategory { get; init;  }

    }
}
