using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Store.DTOS
{
    public class StoreDTO
    {
        public int idStore { get; init; }
        public string Nombre { get; init; } = string.Empty; 
        public string? Descripcion { get; init; }
        public bool Esprincipal { get; init;  }
        public bool Activo { get; init;  }
        public DateTime FechaCreacion { get; init;  }
        public DateTime FechaActulizacion { get; init;  }
        public int? CreadoPor { get; init; }



    }
}
