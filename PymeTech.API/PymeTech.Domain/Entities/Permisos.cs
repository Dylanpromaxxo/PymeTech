using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PymeTech.Domain.Entities
{
    public class Permisos
    {
        public int IdPermiso { get; private set; }
        public string Modulo { get; private set; } 
        public string Accion { get; private set; }
        public string ? Descripcion { get; private set; } 

        public ICollection<RolPermiso> RolPermisos { get; private set; } = new List<RolPermiso>();



        private Permisos() { }  

        public Permisos(string modulo, string accion, string? descripcion = null)
        {
            if (string.IsNullOrWhiteSpace(modulo))
                throw new ArgumentException("El módulo no puede estar vacío");
            if (string.IsNullOrWhiteSpace(accion))
                throw new ArgumentException("La acción no puede estar vacía");
            Modulo = modulo;
            Accion = accion;
            Descripcion = descripcion;
        }   
    }
}
