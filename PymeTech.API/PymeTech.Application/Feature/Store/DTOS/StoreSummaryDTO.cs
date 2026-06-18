using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Store.DTOS
{
    public class StoreSummaryDTO
    {
        public int idStore { get; init; }
        public string Nombre { get; init; } = string.Empty;
        public string? Descripcion { get; init; }
        public bool Esprincipal { get; init; }
        public bool Activo { get; init; }
    }
}
