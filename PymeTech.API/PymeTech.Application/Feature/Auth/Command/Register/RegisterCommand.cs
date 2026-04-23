using MediatR;
using PymeTech.Application.Feature.Auth.AuthDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Auth.Command.Register
{
    public class RegisterCommand :IRequest<RegisterResponseDto>
    {
        // datos del tenant
        public string NombreEmpresa { get; init; } = string.Empty; 
        public string TelefonoEmpresa { get; init; } = string.Empty;

        // datos del primer usuario Admin
        public string Nombre { get; init; } = string.Empty;
        public string Apellido { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string ConfirmarPassword { get; init; } = string.Empty;
    }
}
