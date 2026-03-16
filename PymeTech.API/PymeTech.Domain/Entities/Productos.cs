using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class Productos
    {
        public int IdProducto { get; private set; }
        public int IdTenant { get; private set; }
        public int IdCategoria { get; private set; }
        public string Codigo { get; private set; }
        public string Nombre { get; private set; }
        public string? Descripcion { get; private set; }
        public string UnidadMedida { get; private set; }
        public decimal PrecioVenta { get; private set; }
        public decimal PrecioCompra { get; private set; }
        public bool IvaIncluido { get; private set; }
        public decimal PorcentajeIva { get; private set; }
        public bool EsServicio { get; private set; }
        public bool Activo { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }
        public int? CreadoPor { get; private set; }
        public int? ActualizadoPor { get; private set; }



        // referencias a otras entidades del dominio 

        public Tenant Tenant { get; private set; }
        public Categoria Categoria { get; private set; } // unico con navegaicion 
        public Usuario CreadorProducto { get; private set; }
        public Usuario ActualizadorProducto { get; private set; }


        //Un producto puede estar en varios inventarios (en diferentes almacenes) y puede estar presente en varios detalles de compra y venta, por lo que se definen estas colecciones para representar esas relaciones
        public ICollection<Inventario> Inventarios { get; private set; } = new List<Inventario>(); 
        public ICollection<MovimientosInventario> MovimientosDeInventario { get; private set; } = new List<MovimientosInventario>(); 




        private Productos() { }


        public Productos(int idTenant, int idCategoria, string codigo, string nombre, string? descripcion, string unidadMedida, decimal precioVenta, decimal precioCompra, bool ivaIncluido, decimal porcentajeIva, bool esServicio, int? creadoPor, int? actualizadoPor)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código del producto no puede estar vacío");
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del producto no puede estar vacío");
            if (precioVenta < 0)
                throw new ArgumentException("El precio de venta no puede ser negativo");
            if (precioCompra < 0)
                throw new ArgumentException("El precio de compra no puede ser negativo");
            if (porcentajeIva < 0 || porcentajeIva > 100)
                throw new ArgumentException("El porcentaje de IVA debe estar entre 0 y 100");


            IdTenant = idTenant;
            IdCategoria = idCategoria;
            Codigo = codigo; 
            Nombre = nombre; 
            Descripcion = descripcion; 
            UnidadMedida = unidadMedida; 
            PrecioVenta = precioVenta; 
            PrecioCompra = precioCompra; 
            IvaIncluido = ivaIncluido; 
            PorcentajeIva = porcentajeIva; 
            EsServicio = esServicio; 
            Activo = true; 
            FechaCreacion = DateTime.UtcNow; 
            FechaCreacion = DateTime.UtcNow; 
            CreadoPor = creadoPor; 
            ActualizadoPor = actualizadoPor; 


        }


        public void Desactivar(int actualizadoPor ) {

            Activo = false; 
            FechaActualizacion = DateTime.UtcNow ;
            ActualizadoPor = actualizadoPor; 


        }

    }
}
