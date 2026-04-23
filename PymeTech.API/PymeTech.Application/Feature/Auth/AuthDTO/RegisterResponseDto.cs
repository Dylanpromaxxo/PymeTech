using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Auth.AuthDTO
{
    public class RegisterResponseDto
    {
        public int IdTenant { get; init; }
        public string NombreEmpresa { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Mensaje { get; init; } = string.Empty;
    }
}
