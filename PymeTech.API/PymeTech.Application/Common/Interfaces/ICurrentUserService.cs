using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int IdUsuario { get; }
        int IdTenant { get; }
        string Email { get; }
        string Rol { get; }         
        bool IsAuthenticated { get; }
    }
}
