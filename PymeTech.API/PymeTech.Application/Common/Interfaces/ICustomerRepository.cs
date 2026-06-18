using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.Customer.CustomerDTOs;
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
        Task<Clientes> GetByIdAsync(int idTenant, int idCliente, CancellationToken ct); 
        Task AddAsync(Clientes clinetes, CancellationToken ct);

        Task<IReadOnlyList<Clientes>> SearchAsync(int idTenant ,  string filter, CancellationToken ct);
        Task<PagedResult<SummaryCustomerDTO>> GetPagedAsync(
            int idTenant,
            int pageNumber,
            int pageSize,
            string? search,
            bool? activo,
            CancellationToken ct);


    }
}
