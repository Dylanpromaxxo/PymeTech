using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class Almacenes
    {
        public  int IdAlmacen { get; private  set; } 
        public int IdTenant { get; private set; } 
        public string Nombre { get; private set; } 
        public string ?Descripcion { get; private set; }
        public bool EsPrincipal { get; private set; } 
        public bool Activo { get; private set; } 
        public DateTime FechaCreacion { get; private set; } 
        public DateTime FechaActualizacion { get; private set; } 
        public int? CreadoPor { get; private set; }

        //referencias a otras entidades del dominio 
        public Tenant Tenant { get; private set; } 
        public Usuario CreadorAlmacen { get; private set; } 

        public ICollection<Inventario> Inventarios { get; private set; } = new List<Inventario>();
        public ICollection<MovimientosInventario> MovimientosInventario { get; private set; } = new List<MovimientosInventario>();

        public ICollection<Compra> Compras { get; private set; } = new List<Compra>();
        public ICollection<Venta> Ventas { get; private set; } = new List<Venta>(); 


        private Almacenes() { } 

        public Almacenes(int idTenant, string nombre, string? descripcion, bool esPrincipal, int? creadoPor)
        {
            if(string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del almacén no puede estar vacío");
            IdTenant = idTenant;
            Nombre = nombre;
            Descripcion = descripcion;
            EsPrincipal = esPrincipal;
            Activo = true;
            FechaCreacion = DateTime.UtcNow;
            FechaActualizacion = DateTime.UtcNow;
            CreadoPor = creadoPor;
        }   


        public void ActualizarAlmacen(string nombre, string? descripcion, bool esPrincipal, int? actualizadoPor)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del almacén no puede estar vacío");
            Nombre = nombre;
            Descripcion = descripcion;
            EsPrincipal = esPrincipal;
            FechaActualizacion = DateTime.UtcNow;
            CreadoPor = actualizadoPor;
        }   

        public void DesactivarAlmacen(int? actualizadoPor)
        {
            Activo = false;
            FechaActualizacion = DateTime.UtcNow;
            CreadoPor = actualizadoPor;
        }
        





    }
}
