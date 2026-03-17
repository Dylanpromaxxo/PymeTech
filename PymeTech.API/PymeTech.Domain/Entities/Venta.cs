using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class Venta
    {
        public int IdVenta { get; private set; }
        public int IdTenant { get; private set; }
        public int IdCliente { get; private set; }
        public int IdAlmacen { get; private set; }
        public int IdUsuario { get; private set; } // Vendedor 

        public string NumeroDocumento { get; private set; }
        public string TipoDocumento { get; private set; }
        public DateTime FechaEmision { get; private set; }
        public DateOnly FechaVencimiento { get; private set; }
        public string Estado { get; private set; } // Activo, Anulado, etc.
        public decimal Subtotal { get; private set; }
        public decimal TotalDescuento { get; private set; }
        public decimal TotalIva { get; private set; }
        public decimal Total { get; private set; }
        public char MonedaIso { get; private set; } // S: Soles, D: Dólares, etc.
        public string TipoCambio { get; private set; } // Tipo de cambio utilizado en la venta
        public string? Notas { get; private set; }
        public DateTime FechaCracion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }
        public int CraadoPor { get; private set; }
        public int? ActualizadoPor { get; private set; }


        // relaciones 

        public Tenant Tenant { get; private set; }
        public Clientes Clientes { get; private set; }
        public Almacenes Almacen { get; private set; }
        public Usuario Usuario { get; private set; } // Vendedor

        public Usuario CreadorVenta { get; private set; }
        public Usuario ActualizadorVenta { get; private set; }

        public ICollection<VentaDetalle> VentaDetalles { get; private set; } = new List<VentaDetalle>() {
        };

        private Venta() { }


        public Venta(int idTenant, int idCliente, int idAlmacen, int idUsuario, string numeroDocumento, string tipoDocumento, DateTime fechaEmision, DateOnly fechaVencimiento, string estado, decimal subtotal, decimal totalDescuento, decimal totalIva, decimal total, char monedaIso, string tipoCambio, string? notas, int creadoPor, int? actualizadopor)
        {
            if (string.IsNullOrWhiteSpace(numeroDocumento))
                throw new ArgumentException("El número de documento no puede estar vacío");
            if (string.IsNullOrWhiteSpace(tipoDocumento))
                throw new ArgumentException("El tipo de documento no puede estar vacío");
            if (subtotal < 0)
                throw new ArgumentException("El subtotal no puede ser negativo");
            if (totalDescuento < 0)
                throw new ArgumentException("El total de descuento no puede ser negativo");
            if (totalIva < 0)
                throw new ArgumentException("El total de IVA no puede ser negativo");
            if (total < 0)
                throw new ArgumentException("El total no puede ser negativo");

            IdTenant = idTenant;
            IdCliente = idCliente;
            IdAlmacen = idAlmacen;
            IdUsuario = idUsuario;
            NumeroDocumento = numeroDocumento;
            TipoDocumento = tipoDocumento;
            FechaEmision = DateTime.UtcNow;
            FechaVencimiento = fechaVencimiento;
            Estado = estado;
            Subtotal = subtotal;
            TotalDescuento = totalDescuento;
            TotalIva = totalIva;
            Total = total;
            MonedaIso = monedaIso;
            TipoCambio = tipoCambio;
            Notas = notas;
            FechaCracion = DateTime.UtcNow;
            FechaActualizacion = DateTime.UtcNow;
            CraadoPor = creadoPor;
            ActualizadoPor = actualizadopor;




        }
    }
}
