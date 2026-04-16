using MediatR;
using PymeTech.Application.Common.Exceptions;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Auth.AuthDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Auth.Command.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly  IUserRepository _userRepository;


        public LoginHandler(
       IUserRepository userRepository,
       IPasswordHasher passwordHasher,
       IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }




        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // 1. busca el usuario por email
            var usuario = await _userRepository.GetByEmailAsync(request.idTenant, request.Email , cancellationToken);

            // 2. si no existe — mismo mensaje que password incorrecto por seguridad
            if (usuario == null)
                throw new UnauthorizedException("Credenciales inválidas");

            // 3. verifica el password
            var passwordValido = _passwordHasher.Verify(request.Password, usuario.PasswordHash);

            if (!passwordValido)
                throw new UnauthorizedException("Credenciales inválidas");

            // 4. verifica que el usuario esté activo
            if (!usuario.Activo)
                throw new UnauthorizedException("Usuario inactivo");
            // 5. registra el último login
            usuario.RegistrarLogin();
            await _userRepository.UpdateAsync(usuario, cancellationToken);

            // 6. genera el token
            var token = _jwtService.GenerateToken(usuario);

            return new LoginResponseDto
            {
                Token = token,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                NombreRol = usuario.Rol.NombreRol,
                IdTenant = usuario.IdTenant
            };
        }
    }
}
