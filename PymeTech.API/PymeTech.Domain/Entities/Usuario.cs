using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; private set; }
        public int IdTenant { get; private set; }
        public int IdRol { get; private set; }
        public string Email { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string PasswordHash { get; private set; }
        public bool Activo { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }
        public DateTimeOffset? UltimoLogin { get; private set; }


        // estas lineas hacen referencia a las tablas reales en la base de datos, es decir, a las entidades del dominio
        public Rol Rol { get; private set; }
        public Tenant Tenant { get; private set; }


        public ICollection<RolPermiso> PermisosAsignados { get; private set; } = new List<RolPermiso>();

        //Colecciones para registrar las acciones del usuario 
        public ICollection<Clientes> ClientesCreados { get; private set; } = new List<Clientes>();
        public ICollection<Clientes> ClientesActulizados { get; private set; } = new List<Clientes>();
        //Colecciones para otras entidades como Proveedores

        public ICollection<Proveedores> ProveedoresCreados { get; private set; } = new List<Proveedores>();
        public ICollection<Proveedores> ProveedoresActualizados { get; private set; } = new List<Proveedores>();

        //colecciones para otras entidades como Categorias 

        public ICollection<Categoria> CategoriasCreadas { get; private set; } = new List<Categoria>();

        // colecciones para Almacenes 

        public ICollection<Almacenes> AlmacenesCreados { get; private set; } = new List<Almacenes>();

        //Coleccion para productos
        public ICollection<Productos> ProductosCreados { get; private set; } = new List<Productos>();
        public ICollection<Productos> ProductosActualizados { get; private set; } = new List<Productos>();

        //colecciones para Compra

        public ICollection<Compra> ComprasCreadas { get; private set; } = new List<Compra>();
        public ICollection<Compra> ComprasActualizadas { get; private set; } = new List<Compra>();





        private Usuario() { }

        public Usuario(int idTenat, int idRol, string email, string nombre, string apellido, string passwordhash)
        {

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
