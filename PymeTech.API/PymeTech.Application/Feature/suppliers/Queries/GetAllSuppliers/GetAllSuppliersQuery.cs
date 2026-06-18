using MediatR;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.suppliers.SuppliersDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IRequest<PagedResult<SupplerSummaryDTO>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }

    }
}
