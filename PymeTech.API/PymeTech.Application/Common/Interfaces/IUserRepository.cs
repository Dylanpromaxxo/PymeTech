using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario?> AddAsync (Usuario usuario, CancellationToken ct);
        Task<bool> EmailExistaAsync(string email ,  CancellationToken ct ); 
        Task<Usuario> GetByEmailAsync(int idTenant , string email , CancellationToken ct);
        Task<bool> UpdateAsync(Usuario usuario, CancellationToken ct);
    }
}
