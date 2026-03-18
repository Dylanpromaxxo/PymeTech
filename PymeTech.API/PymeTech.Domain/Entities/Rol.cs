using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class Rol
    {
        public int IdRol { get; private set; }
        public int IdTenant { get; private set; }
        public string NombreRol { get; private set; }
        public string Descripcion { get; private set; }
        public bool Activo { get; private set; }
        public DateTime FechaCreacion { get; private set; }


        // Esta hace las referencias osea tiene muchos usuarios y un tenant, es decir, a las entidades del dominio , NO A LAS DE ENTITY FRAMEWORK

        public ICollection<Usuario> Usuarios { get; private set; } = new List<Usuario>();
        public ICollection<RolPermiso> RolPermisos { get; private set; } = new List<RolPermiso>();
        public Tenant Tenant { get; private set; }


        private Rol() { }

        public Rol(int idTenant, string nombreRol, string descripcion)
        {

            if (string.IsNullOrWhiteSpace(nombreRol))
                throw new ArgumentException("El nombre del rol no puede estar vacío");

            IdTenant = idTenant;
            NombreRol = nombreRol;
            Descripcion = descripcion;
            Activo = true;
            FechaCreacion = DateTime.UtcNow;

        }


        public void Desactivar()
        {
            Activo = false;
        }
    }
}
