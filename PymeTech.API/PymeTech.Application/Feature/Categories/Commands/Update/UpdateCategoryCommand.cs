using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Commands.Update
{
    public class UpdateCategoryCommand: IRequest<int>
    {
        public int IdCategory { get; init;  }
        public string Nombre { get; init; } = string.Empty; 
        public string ? Descripcion { get; init;  }
       
    }
}
