using MediatR;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.suppliers.SuppliersDTOs;
using PymeTech.Domain.Entities;
using PymeTech.Application.Common.Exceptions;
using Microsoft.VisualBasic;

namespace PymeTech.Application.Feature.suppliers.Queries.GetSupplierById
{
    public class GetSupplierbyIdHandler : IRequestHandler<GetSupplierByIdQuery, SupplerDTO>
    {
        private readonly ISuppliersRepository _repository;
        private readonly ICurrentUserService _currentUser;


        public GetSupplierbyIdHandler(ISuppliersRepository repository , ICurrentUserService user  )
        {
            _repository = repository;
            _currentUser = user;


        }


        public async Task<SupplerDTO> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            Proveedores data = await _repository.GetByIdAsync(_currentUser.IdTenant, request.IdSupplier, cancellationToken);

            if(data == null) 
            {
                throw new NotFoundException("Suppliers", request.IdSupplier); 
            }

            return new SupplerDTO 
            {
                IdProveedor = data.IdProveedor , 
                IdTenant = data.IdTenant , 
                NombreContacto  = data.NombreContacto , 
                Email = data.Email , 
                TipoDocumento = data.TipoDocumento , 
                NumeroDocumento = data.NumeroDoc, 
                RazonSocial = data.RazonSocial , 
                Telefono = data.Telefono , 
                Direccion = data.Direccion , 
                Activo = data.Activo , 
                FechaCreacion = data.FechaCreacion 

            };



        }
    }
}
