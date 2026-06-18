using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Exceptions;
namespace PymeTech.Application.Feature.Categories.Commands.ChangeStatus
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCategoryCommad, Unit>
    {

        private readonly ICategoriesRepository _repository; 
        private readonly ICurrentUserService _currentUser; 
        private readonly IUnitOfWork _unitOfWork;

        public ChangeStatusCommandHandler(ICategoriesRepository repository, ICurrentUserService currentUser, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _currentUser = currentUser;
            _unitOfWork = unitOfWork;
        }



        public async Task<Unit> Handle(ChangeStatusCategoryCommad request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(_currentUser.IdTenant, request.IdCategory, cancellationToken);

            if (category == null)
                throw new NotFoundException("Categories", request.IdCategory);

            category.ChangeStatus();
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;




        }
    }
}
