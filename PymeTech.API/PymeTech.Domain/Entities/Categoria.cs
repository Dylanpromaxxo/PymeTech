using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class Categoria
    {
        public int IdCategoria { get; private set; }
        public int IdTenant { get; private set; }
        public string Nombre { get; private set; }
        public string? Descripcion { get; private set; }
        public bool Activo { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }
        public int? CreadoPor { get; private set; }

        // referencias a otras entidades del dominio 

        public Tenant Tenant { get; private set; }
        public Usuario CreadorCategoria { get; private set; }


        /// Colecciones para registrar las acciones del usuario 
        public ICollection<Productos> Productos { get; private set; } = new List<Productos>();



        private Categoria() { }


        public Categoria(int idTenant, string nombre, string descripcion, int? creadoPor)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío");
            IdTenant = idTenant;
            Nombre = nombre;
            Descripcion = descripcion;
            Activo = true;
            FechaCreacion = DateTime.UtcNow;
            FechaActualizacion = DateTime.UtcNow;
            CreadoPor = creadoPor;
        }

    }
}
