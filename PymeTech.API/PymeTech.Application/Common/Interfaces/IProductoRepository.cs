using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Common.Interfaces
{
    public interface IProductoRepository
    {
        Task<Productos> AddAsync(Productos producto , CancellationToken ct);
    }
}
