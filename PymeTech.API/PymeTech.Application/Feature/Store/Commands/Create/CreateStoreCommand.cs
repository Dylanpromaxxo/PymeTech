using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Store.Commands.Create
{
    public class CreateStoreCommand : IRequest<int>
    {
        public string Nombre { get; init; } = string.Empty; 
        public string ? Descripcion { get; init;  } 
        public bool EsPrincipal { get; init;  }

    }
}
