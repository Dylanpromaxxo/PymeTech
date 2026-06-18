using MediatR;
using PymeTech.Application.Feature.Store.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Store.Queries.GetById
{
    public class GetStoreByIdQuery : IRequest<StoreDTO>
    {
        public int IdStore { get; init; } 

    }
}
