using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Commands.Create
{
    public class CreateCategoriCommand : IRequest<int>
    {
        public string Nombre { get; init; } = string.Empty;
        public string? Descripcion { get; init; }
    }
}
