using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Auth.AuthDTO
{
    public class LoginResponseDto
    {
        public string Token { get; init; }
        public string Nombre { get; init; }
        public string Email { get; init; }
        public string NombreRol { get; init; }
        public int IdTenant { get; init; }
    }
}
