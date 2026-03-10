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
    }
}
