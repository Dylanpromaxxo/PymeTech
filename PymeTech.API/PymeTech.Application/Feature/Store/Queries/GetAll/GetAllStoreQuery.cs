using MediatR;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Store.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Store.Queries.GetAll
{
    public class GetAllStoreQuery : IRequest<PagedResult<StoreSummaryDTO>>
    {
        public int PageNumber { get; init;  }
        public int PageSize { get; init; }
        public bool? Activo { get; init;  }

    }
}
