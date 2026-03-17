using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class VentaDetalle
    {
        public int IdVentaDetalle { get; private set; }  
        public int IdTenant { get; private set; } 
        public int IdVenta { get; private set; } 
        public int IdProducto { get; private set; } 
        public decimal Cantidad { get; private set; } 
        public decimal PrecioUnitario { get; private set; }
        public decimal PorcentajeDto { get; private set; } 
        public decimal MontoDescuento { get; private set; } 
        public decimal PorcentajeIva { get; private set; } 
        public decimal MontoIva { get; private set; } 
        public decimal Subtotal { get; private set; } 
        public decimal Total { get; private set; } 
        public string Notas { get; private set; }


        // relaciones 
        public Tenant tenant { get; private set; } 
        public Venta venta { get; private set; } 
        public Productos producto { get; private set; }




        private VentaDetalle() { } 
        public VentaDetalle(int idTenant ,  int idVenta, int idProducto, decimal cantidad, decimal precioUnitario, decimal porcentajeDto, decimal montoDescuento, decimal porcentajeIva, decimal montoIva, decimal subtotal, decimal total, string notas)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero");
            if (precioUnitario < 0)
                throw new ArgumentException("El precio unitario no puede ser negativo");
            if (porcentajeDto < 0 || porcentajeDto > 100)
                throw new ArgumentException("El porcentaje de descuento debe estar entre 0 y 100");
            if (porcentajeIva < 0 || porcentajeIva > 100)
                throw new ArgumentException("El porcentaje de IVA debe estar entre 0 y 100");


            IdTenant = idTenant;
            IdVenta = idVenta;
            IdProducto = idProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            PorcentajeDto = porcentajeDto;
            MontoDescuento = montoDescuento;
            PorcentajeIva = porcentajeIva;
            MontoIva = montoIva;
            Subtotal = subtotal;
            Total = total;
            Notas = notas;
        } 

    }

}
