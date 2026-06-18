using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.Commands.ChangeStatus
{
    public class ChangeStatusCustomerValidator : AbstractValidator<ChangeStatusCustomerCommand>
    {
        public ChangeStatusCustomerValidator()
        {
            RuleFor(c=> c.IdCliente).GreaterThan(0).NotEmpty();
        }

    }
}
