using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class CompraDetalle
    {
        public int IdCompraDetalle { get; private set; }
        public int IdTenant { get; private set; }
        public int IdCompra { get; private set; }
        public int IdProducto { get; private set; }
        public decimal CantidadPedida { get; private set; }
        public decimal CantidadRecibida { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public decimal PorcentajeDto { get; private set; }
        public decimal MontoDescuento { get; private set; }
        public decimal PorcentajeIva { get; private set; }
        public decimal MontoIva { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal Total { get; private set; }
        public string? Notas { get; private set; }

        //Referencias a entidades
        public Tenant Tenant { get; private set; }
        public Compra Compra { get; private set; }
        public Productos Producto { get; private set; }

        //Constructor privado para EF core

        private CompraDetalle() { }

        public CompraDetalle(
            int idTenant,
            int idCompra,
            int idProducto,
            decimal cantidadPedida,
            decimal cantidadRecibida,
            decimal precioUnitario,
            decimal porcentajeDto,
            decimal montoDescuento,
            decimal porcentajeIva,
            decimal montoIva,
            decimal subTotal,
            decimal total,
            string? notas)
        {
            //Validaciones
            if (cantidadPedida <= 0)
                throw new ArgumentException("La cantidad pedida debe ser mayor a 0");

            if (precioUnitario <= 0)
                throw new ArgumentException("El precio unitario debe ser mayor a 0");

            if (total < 0)
                throw new ArgumentException("El total no puede ser negativo");

            IdTenant = idTenant;
            IdCompra = idCompra;
            IdProducto = idProducto;
            CantidadPedida = cantidadPedida;
            CantidadRecibida = cantidadRecibida;
            PrecioUnitario = precioUnitario;
            PorcentajeDto = porcentajeDto;
            MontoDescuento = montoDescuento;
            PorcentajeIva = porcentajeIva;
            MontoIva = montoIva;
            SubTotal = subTotal;
            Total = total;
            Notas = notas;
        }

}
}
