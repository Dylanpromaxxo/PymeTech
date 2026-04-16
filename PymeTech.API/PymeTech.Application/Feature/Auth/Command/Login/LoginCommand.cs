using MediatR;
using PymeTech.Application.Feature.Auth.AuthDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Auth.Command.Login
{
    public class LoginCommand : IRequest<LoginResponseDto>
    {
        public int idTenant { get; init; }  
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
