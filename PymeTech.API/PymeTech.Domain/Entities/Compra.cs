using System;
using System.Collections.Generic;

namespace PymeTech.Domain.Entities
{
    public class Compra
    {
        public int IdCompra { get; private set; }
        public int IdTenant { get; private set; }
        public int IdProveedor { get; private set; }
        public int IdAlmacen { get; private set; }
        public int IdUsuario { get; private set; }

        public string NumeroDocumento { get; private set; }
        public string? NumeroFacturaProv { get; private set; }
        public string TipoDocumento { get; private set; }

        public DateTime FechaEmision { get; private set; }
        public DateTime? FechaRecepcion { get; private set; }

        public string Estado { get; private set; }

        public decimal SubTotal { get; private set; }
        public decimal TotalDescuento { get; private set; }
        public decimal TotalIva { get; private set; }
        public decimal Total { get; private set; }

        public string MonedaISO { get; private set; }
        public decimal TipoCambio { get; private set; }

        public string? Notas { get; private set; }

        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }

        public int CreadoPor { get; private set; }
        public int? ActualizadoPor { get; private set; }

        // Referencias a otras entidades
        public Tenant Tenant { get; private set; }
        public Proveedores Proveedor { get; private set; }
        public Almacenes Almacen { get; private set; }
        public Usuario Usuario { get; private set; }
        public Usuario CreadorCompra { get; private set; }
        public Usuario ActualizadorCompra { get; private set; }

        //collection de compradetalle
        public ICollection<CompraDetalle> Detalles { get; private set; }

        // Constructor privado para EF Core
        private Compra() { }

        public Compra(
            int idTenant,
            int idProveedor,
            int idAlmacen,
            int idUsuario,
            string numeroDocumento,
            string? numeroFacturaProv,
            string tipoDocumento,
            DateTime fechaEmision,
            DateTime? fechaRecepcion,
            string estado,
            decimal subTotal,
            decimal totalDescuento,
            decimal totalIva,
            decimal total,
            string monedaISO,
            decimal tipoCambio,
            string? notas,
            int creadoPor,
            int actualizadoPor)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(numeroDocumento))
                throw new ArgumentException("El número de documento no puede estar vacío");
            if (string.IsNullOrWhiteSpace(tipoDocumento))
                throw new ArgumentException("El tipo de documento no puede estar vacío");
            if (subTotal < 0)
                throw new ArgumentException("El subtotal no puede ser negativo");
            if (total < 0)
                throw new ArgumentException("El total no puede ser negativo");
            if (string.IsNullOrWhiteSpace(monedaISO))
                throw new ArgumentException("La moneda no puede estar vacía");

            IdTenant = idTenant;
            IdProveedor = idProveedor;
            IdAlmacen = idAlmacen;
            IdUsuario = idUsuario;
            NumeroDocumento = numeroDocumento;
            NumeroFacturaProv = numeroFacturaProv;
            TipoDocumento = tipoDocumento;
            FechaEmision = fechaEmision;
            FechaRecepcion = fechaRecepcion;
            Estado = estado;
            SubTotal = subTotal;
            TotalDescuento = totalDescuento;
            TotalIva = totalIva;
            Total = total;
            MonedaISO = monedaISO;
            TipoCambio = tipoCambio;
            Notas = notas;
            FechaCreacion = DateTime.UtcNow;
            FechaActualizacion = DateTime.UtcNow;
            CreadoPor = creadoPor;
            ActualizadoPor = actualizadoPor;
        }
    }
}