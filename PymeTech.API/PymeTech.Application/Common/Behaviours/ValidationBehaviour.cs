using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PymeTech.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validator )
        {
            _validator = validator;
            
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator.Any()) 
            {
                var context = new ValidationContext<TRequest>(request);

                var failures = _validator
                    .Select(v => v.Validate(context))
                    .SelectMany(v => v.Errors)
                    .Where(w => w != null)
                    .ToList();


                if (failures.Any()) 
                {
                    throw new ValidationException(failures);
                }
               
            
            }
            return await next();
        }
    }
}
