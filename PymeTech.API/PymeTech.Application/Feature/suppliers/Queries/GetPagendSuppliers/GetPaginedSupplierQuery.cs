using MediatR;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.suppliers.SuppliersDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.suppliers.Queries.GetPagendSuppliers
{
    public class GetPaginedSupplierQuery : IRequest<PagedResult<SupplerSummaryDTO>>
    {
        public int PageNumber { get; init;  }
        public int PageSize { get; init; }
        public string ? Search { get; init;  }
        public bool ? Activo { get; init;  }
    }
}
