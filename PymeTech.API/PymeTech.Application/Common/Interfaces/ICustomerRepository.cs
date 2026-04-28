using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<Clientes>> GetAllCustomer(int idTenant, CancellationToken ct  );
        Task AddAsync(Clientes clinetes, CancellationToken ct); 
    }
}
