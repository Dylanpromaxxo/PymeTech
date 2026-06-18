using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Categories.DTOS
{
    public class CategoriesDTO
    {
        public int IdCategoria { get; init;  }
        public string Nombre { get; init; } = string.Empty; 
        public string? Descripcion { get; init; } 
        public bool Activo { get; init;  }
        public DateTime FechaCreacion { get; init; }
        public DateTime? FechaActualizacion { get; init ; }
    
    }
}
