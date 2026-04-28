using Microsoft.AspNetCore.Http;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure.Persistence.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }




        public int IdUsuario 
        {
            get 
            {
                var value = _httpContextAccessor.HttpContext?.User?.FindFirst("IdUsuario")?.Value;
                return int.TryParse(value, out var idUsuario) ? idUsuario : 0; 
            }
        }

        public int IdTenant
        {
            get
            {
                var value = _httpContextAccessor.HttpContext?.User?.FindFirst("IdTenant")?.Value;
                return int.TryParse(value, out var idTenant) ? idTenant : 0;
            }
        }

        public string Email => _httpContextAccessor.HttpContext?.User.FindFirst("Email")?.Value ?? string.Empty ;

        public string Rol => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;


        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
