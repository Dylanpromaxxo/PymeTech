using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public  class Tenant
    {
        public int IdTenant { get; private set; } 
        public string Nombre { get; private set;  }
        public string Email { get; private set; } 
        public string Telefono { get; private set; } 
        public string PlanSuscripcion { get; private set; }    
        public DateTime FechaCreacion { get; private set; } 
        public bool  Activo { get; private set; }


        // estas lineas hacen referencia a que Tenant tiene muchos usuarios y muchos roles, es decir, a las entidades del dominio , 
        // NO A LAS DE ENTITY FRAMEWORK
        public ICollection<Usuario> Usuarios { get; private set; } = new List<Usuario>();
        public ICollection<Rol> Roles { get; private set; } = new List<Rol>();
        public ICollection<RolPermiso> RolPermisos { get; private set; } = new List<RolPermiso>();

        private Tenant() { }

        public Tenant(string nombre, string email, string telefono ) {
            
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
            PlanSuscripcion = "BASICO";
            FechaCreacion = DateTime.UtcNow;
            Activo = true;
        }


        public void CambiarPlan(string nuevoPlan) 
        {
            PlanSuscripcion = nuevoPlan;
        }

        public void Desactivar() { 
            Activo = false; 
        }



    }
}
