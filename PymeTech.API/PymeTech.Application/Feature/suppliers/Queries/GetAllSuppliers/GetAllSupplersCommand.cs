using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Queries.GetAllSuppliers
{
    public record GetAllSupplersCommand : IRequest<List<>>
    {
    }
}
