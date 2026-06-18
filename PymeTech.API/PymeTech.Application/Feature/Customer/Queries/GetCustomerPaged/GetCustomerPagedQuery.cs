using MediatR;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Queries.GetCustomerPaged
{
    public class GetCustomerPagedQuery : IRequest<PagedResult<SummaryCustomerDTO>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public  string ? Seach { get; init; } 
         public bool ? Activo { get; init; } 

    }
}
