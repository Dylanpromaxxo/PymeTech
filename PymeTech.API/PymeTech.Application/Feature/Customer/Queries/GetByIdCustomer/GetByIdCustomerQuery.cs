using MediatR;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Queries.GetByIdCustomer
{
    public class GetByIdCustomerQuery : IRequest<CustomerDTO>
    {
        public int IdCliente { get; init;  }
    }
}
