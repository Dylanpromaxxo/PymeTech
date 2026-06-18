using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Commands.de_ete
{
    public class DeleteSupplierCommad : IRequest<bool>
    {
        public int idProveedor { get; init; }
    }
}
