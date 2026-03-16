using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class MovimientosInventario
    {
        public int IdMovimiento { get; private set; }
        public int IdTenant { get; private set; }
        public int IdProducto { get; private set; }
        public int IdAlmacen { get; private set; }
        public int IdUsuario { get; private set; }
        public string TipoMovimiento { get; private set; }
        public decimal Cantidad { get; private set; }
        public decimal StockAnterior { get; private set; }
        public decimal StockNuevo { get; private set; }
        public string ReferenciaTipo { get; private set; }
        public int ReferenciaId { get; private set; }
        public string Notas { get; private set; }
        public DateTime FechaCreacion { get; private set; }

        public Tenant Tenant { get; private set; } 
        public Productos Producto { get; private set; }
        public Almacenes Almacen { get; private set; } 
        public Usuario Usuario { get; private set; }




        private MovimientosInventario() { } 
        public MovimientosInventario(int idtenant , int idproducto , int idAlmacen , int idUsuario , string tipoMovimiento , decimal cantidad , 
         decimal stockAnterior , decimal stockNuevo , string referenciaTipo , int referenciaId , string notas  )
        {
            IdTenant = idtenant; 
            IdProducto = idproducto; 
            IdUsuario = idUsuario; 
            TipoMovimiento = tipoMovimiento; 
            Cantidad = cantidad; 
            StockAnterior = stockAnterior; 
            StockNuevo = stockNuevo; 
            ReferenciaTipo = referenciaTipo; 
            ReferenciaId = referenciaId; 
            Notas = notas; 
            FechaCreacion = DateTime.UtcNow; 


        }



    }
}
