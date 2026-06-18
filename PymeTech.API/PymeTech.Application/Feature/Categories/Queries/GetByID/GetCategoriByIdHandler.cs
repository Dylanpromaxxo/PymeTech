using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Categories.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.Queries.GetByID
{
    public class GetCategoriByIdHandler : IRequestHandler<GetCategoriesByIdQuery, CategoriesDTO>
    {
        private readonly ICategoriesRepository _repository;
        private readonly ICurrentUserService _currentUser; 


        public GetCategoriByIdHandler(ICurrentUserService currentUser , ICategoriesRepository repository)
        {
            _currentUser = currentUser;
            _repository = repository;
        }

        public async Task<CategoriesDTO> Handle(GetCategoriesByIdQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _repository.GetByIdAsync(_currentUser.IdTenant, request.CategoriId, cancellationToken);

            return new CategoriesDTO
            {
                IdCategoria = categoria.IdCategoria,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                Activo = categoria.Activo,
                FechaActualizacion = categoria.FechaActualizacion,
                FechaCreacion = categoria.FechaCreacion

            };

        }
    }
}
