using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public  class Usuario
    {
        public int IdUsuario { get; private set;  }
        public int IdTenant { get; private set; }
        public int IdRol { get; private set; }
        public string Email { get; private set; } 
        public string Nombre { get; private set; } 
        public string Apellido { get; private set; } 
        public string PasswordHash { get; private set; } 
        public bool Activo { get; private set; } 
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; } 
        public DateTime? UltimoLogin  { get; private set; }


        // estas lineas hacen referencia a las tablas reales en la base de datos, es decir, a las entidades del dominio
        public Rol Rol { get; private set; }
        public Tenant Tenant { get; private set; }


        public ICollection<RolPermiso> RolPermisos { get; private set; } = new List<RolPermiso>();

        private Usuario() { }

        public Usuario(int idTenat, int idRol, string email, string nombre, string apellido, string passwordhash ) {
            
            IdTenant = idTenat;
            IdRol = idRol; 
            Email = email; 
            Nombre = nombre; 
            Apellido = apellido; 
            PasswordHash = passwordhash;
            Activo = true;
            FechaCreacion = DateTime.UtcNow;
            FechaActualizacion = DateTime.UtcNow;
           

        }

        // Metodos para las entidades del dominio 


        public void RegistrarLogin() 
        { 
            UltimoLogin = DateTime.UtcNow; 
        }

        public void CambiarPassword(string nuevoPasswordHash) 
        { 
            PasswordHash = nuevoPasswordHash; 
            FechaActualizacion = DateTime.UtcNow;
        }
        public void DesactivarUsuario() 
        {
            Activo = false; 
            FechaActualizacion = DateTime.UtcNow; 

        }


    }
}
