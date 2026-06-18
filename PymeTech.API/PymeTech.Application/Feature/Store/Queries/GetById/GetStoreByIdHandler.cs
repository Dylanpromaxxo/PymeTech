using MediatR;
using Microsoft.VisualBasic;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Store.DTOS;
using PymeTech.Application.Common.Exceptions;
namespace PymeTech.Application.Feature.Store.Queries.GetById
{
    public class GetStoreByIdHandler : IRequestHandler<GetStoreByIdQuery, StoreDTO>
    {
        private readonly IStroreRepository _repository;
        private readonly ICurrentUserService _currentUser;

        public GetStoreByIdHandler( ICurrentUserService current , IStroreRepository repository )
        {
            _repository = repository;
            _currentUser = current; 
            
        }



        public async Task<StoreDTO> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var store = await _repository.GetById(_currentUser.IdTenant, request.IdStore, cancellationToken);

            if (store == null)
                throw new NotFoundException("almacen", request.IdStore);

            return new StoreDTO
            {
                idStore = store.IdAlmacen,
                Nombre = store.Nombre,
                Descripcion = store.Descripcion,
                FechaActulizacion = store.FechaActualizacion,
                FechaCreacion = store.FechaCreacion,
                Activo = store.Activo,
                Esprincipal = store.EsPrincipal,
                CreadoPor = store.CreadoPor

            };

        }
    }
}
