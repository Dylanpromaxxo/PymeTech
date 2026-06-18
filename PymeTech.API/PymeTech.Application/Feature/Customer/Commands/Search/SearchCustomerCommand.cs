using MediatR;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Commands.Search
{
    public record SearchCustomerCommand  : IRequest<List<SummaryCustomerDTO>>
    {
        public string Filter { get; set;  }
    }
}
