using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario> GetByEmailAsync(int idTenant , string email , CancellationToken ct);
        Task<bool> UpdateAsync(Usuario usuario, CancellationToken ct);
    }
}
