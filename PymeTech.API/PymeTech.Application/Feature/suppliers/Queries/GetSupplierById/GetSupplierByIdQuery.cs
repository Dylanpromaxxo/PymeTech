using MediatR;
using PymeTech.Application.Feature.suppliers.SuppliersDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQuery:IRequest<SupplerDTO>
    {
        public int IdSupplier { get; init; } 
    }
}
