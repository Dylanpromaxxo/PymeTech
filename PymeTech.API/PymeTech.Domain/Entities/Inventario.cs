using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class Inventario
    {
        public int IdInventario { get; private set; } 
        public int IdTenant { get; private set; }
        public int IdProducto { get; private set; }
        public int IdAlmacen { get; private set; } 
        public decimal StockActual { get; private set; } 
        public decimal StockMinimo { get; private set; } 
        public decimal? StockMaximo { get; private set; } 
        public DateTime FechaActualizacion { get; private set; } 

        public Tenant Tenant { get; private set; } 
        public Productos Producto { get; private set; } 
        public Almacenes Almacen { get; private set; }

        private Inventario() { }
        public Inventario(int idTenant , int idProducto , int idAlmancen , decimal stockActual , decimal stockMinimo , decimal stockMaximo) {
        
            IdTenant = idTenant;
            IdProducto = idProducto; 
            IdAlmacen = idAlmancen; 
            StockActual = stockActual; 
            StockMinimo = stockMinimo; 
            StockMaximo = stockMaximo; 
            FechaActualizacion = DateTime.UtcNow; 

        }

     





    }
}
