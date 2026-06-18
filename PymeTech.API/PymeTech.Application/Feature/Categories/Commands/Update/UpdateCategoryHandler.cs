using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Exceptions;
namespace PymeTech.Application.Feature.Categories.Commands.Update
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, int>
    {
        private readonly ICategoriesRepository _repository;
        private readonly ICurrentUserService _currentUser;
        private readonly IUnitOfWork _unitOfwork;

        public UpdateCategoryHandler(ICategoriesRepository category , ICurrentUserService currentUser , IUnitOfWork unitofwork)
        {
            _repository = category;
            _currentUser = currentUser;
            _unitOfwork = unitofwork; 
        }



        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(_currentUser.IdTenant, request.IdCategory, cancellationToken);

            if (category == null) 
            {
                throw new NotFoundException("category", request.IdCategory);
            }

            category.Update(request.Nombre, request.Descripcion);
            await _unitOfwork.SaveAsync(cancellationToken);

            return category.IdCategoria;



        }
    }
}
