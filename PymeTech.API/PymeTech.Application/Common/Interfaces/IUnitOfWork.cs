using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(CancellationToken ct); 
        Task CommitAsync (CancellationToken ct);
        Task RollBackAsync(CancellationToken ct);  
        Task SaveAsync(CancellationToken ct);
    }
}
