using MediatR;
using Microsoft.VisualBasic;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Auth.AuthDTO;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Auth.Command.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand , RegisterResponseDto>
    {
         
        private readonly IUserRepository _userRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IPermisosRepository _permisosRepository; 

        public RegisterHandler(IUserRepository user , ITenantRepository tenant , IUnitOfWork unitOfWork , IPasswordHasher passwordHasher , IPermisosRepository permisosRepository )
        {
           
            _userRepository = user; 
            _tenantRepository = tenant; 
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _permisosRepository = permisosRepository; 
        }

        async Task<RegisterResponseDto> IRequestHandler<RegisterCommand, RegisterResponseDto>.Handle(RegisterCommand request, CancellationToken cancellationToken)
        {


            var EmailExist = await _userRepository.EmailExistaAsync(request.Email, cancellationToken);
            

            if (EmailExist)
            {
                throw new ApplicationException("El correo electrónico ya está registrado");
            }




            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try 
            {
                var tenant = new Tenant(request.NombreEmpresa, request.Email, request.TelefonoEmpresa);
                var permisos = await _permisosRepository.GetAllAsync(cancellationToken);

                await _tenantRepository.AddAsync(tenant, cancellationToken);

                // ✅ GUARDAR EL TENANT PRIMERO para que IdTenant se asigne
                await _unitOfWork.SaveAsync(cancellationToken);
                // Ahora tenant.IdTenant = 1, 2, 3, etc (ya no es 0)

                // 1️⃣ Crear el Rol (ahora tenant.IdTenant tiene valor real)
                var rolAdmin = new Rol(tenant, "Administrador", "Acceso total");

                // 2️⃣ Asignar permisos (RolPermiso.IdTenant tendrá valor)
                foreach (var permiso in permisos)
                {
                    rolAdmin.AssignPermission(permiso);
                }

                // 3️⃣ Agregar rol a tenant
                tenant.Roles.Add(rolAdmin);

                // 4️⃣ Crear usuario
                var passwordHash = _passwordHasher.Hash(request.Password);
                var user = new Usuario(tenant, rolAdmin, request.Email, request.Nombre, request.Apellido, passwordHash);
                tenant.Usuarios.Add(user);

                // 5️⃣ GUARDAR EL RESTO
                await _unitOfWork.SaveAsync(cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);




                return new RegisterResponseDto
                {
                    IdTenant = tenant.IdTenant, 
                    Email = request.Email, 
                    NombreEmpresa = tenant.Nombre, 
                    Mensaje = "Registro exitoso"

                }; 



            }
            catch 
            {
                await _unitOfWork.RollBackAsync(cancellationToken);
                throw; 
            }


        }

    }
}
