using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class RolPermiso
    {

        // Tabla con 4 Relaciones Tenant , Rol , Permiso y usuarios
        public int IdTenant { get; private set; }
        public int IdRol { get; private set; }
        public int IdPermiso { get; private set; }
        public DateTime FechaAsignado { get; private set; }
        public int? AsignadoPor { get; private set; }

        //referencias 
        public Tenant Tenant { get; private set; }
        public Rol Rol { get; private set; }
        public Permisos Permiso { get; private set; }
        public Usuario UsuarioAsignado { get; private set; }



        private RolPermiso() { }


        public RolPermiso(int idTenant, int idRol, int idPermiso, int? asignadoPor = null)
        {
            IdTenant = idTenant;
            IdRol = idRol;
            IdPermiso = idPermiso;
            FechaAsignado = DateTime.UtcNow;
            AsignadoPor = asignadoPor;
        }


        public RolPermiso(Rol rol,Permisos permiso) 
        {
            Rol = rol;
            Permiso = permiso;

            IdRol = rol.IdRol;
            IdTenant = rol.IdTenant;
            IdPermiso = permiso.IdPermiso;
            

            FechaAsignado = DateTime.UtcNow; 

        }
        

    }
}
