using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Commands.ChangeStatus
{
    public record ChangeStatusCustomerCommand: IRequest<bool>
    {
        public int IdCliente { get; init;  }


    }
}
