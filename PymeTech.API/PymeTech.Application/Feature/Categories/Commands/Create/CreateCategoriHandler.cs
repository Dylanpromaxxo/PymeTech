using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Commands.Create
{
    public class CreateCategoriHandler : IRequestHandler<CreateCategoriCommand, int>
    {
        private readonly ICategoriesRepository _repository;
        private readonly ICurrentUserService _currentUser;
        private readonly IUnitOfWork _unitOfWork; 
        public CreateCategoriHandler(ICategoriesRepository repository , ICurrentUserService user , IUnitOfWork unit)
        {
            _currentUser = user;
            _repository = repository;
            _unitOfWork = unit; 

        }

        public async Task<int> Handle(CreateCategoriCommand request, CancellationToken cancellationToken)
        {
            var category = new Categoria(_currentUser.IdTenant, request.Nombre, request.Descripcion, _currentUser.IdUsuario);
            await _unitOfWork.SaveAsync(cancellationToken);

            return category.IdCategoria;
        }
    }
}
