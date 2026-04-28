using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class Clientes
    {
        public int IdCliente { get; private set; }
        public int IdTenant { get; private set; }
        public string TipoDocumento { get; private set; }
        public string NumeroDoc { get; private set; }
        public string RazonSocial { get; private set; }
        public string NombreContacto { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public string Direccion { get; private set; }
        public string Tipo { get; private set; }
        public bool Activo { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }
        public int? CreadoPor { get; private set; }
        public int? ActualizadoPor { get; private set; }


        public Tenant Tenant { get; private set; }
        public Usuario CreadorClientes { get; private set; }
        public Usuario ActualizadorClientes { get; private set; }

        public ICollection<Venta> Ventas { get; private set; } = new List<Venta>();






        private Clientes() { }


        public Clientes(int idTenant, string tipoDoc, string numeroDoc, string razonSocial, string nombreContacto, string email, string telefono, string direccion, string tipo, int? creadoPor)
        {
            if (string.IsNullOrWhiteSpace(numeroDoc))
                throw new ArgumentException("El número de documento no puede estar vacío");

            if (string.IsNullOrWhiteSpace(razonSocial))
                throw new ArgumentException("La razón social no puede estar vacía");


            tipoDoc = tipoDoc.Trim().ToUpper();
            tipo = tipo.Trim().ToUpper();

            if (!TiposDocumento.Validos.Contains(tipoDoc))
                throw new ArgumentException("Tipo de documento inválido");

            if (!TiposCliente.Validos.Contains(tipo))
                throw new ArgumentException("Tipo de cliente inválido");



            IdTenant = idTenant;
            TipoDocumento = tipoDoc;
            NumeroDoc = numeroDoc;
            RazonSocial = razonSocial;
            NombreContacto = nombreContacto;
            Email = email.Trim().ToLowerInvariant();
            Telefono = telefono;
            Direccion = direccion;
            Tipo = tipo;
            Activo = true;
            FechaCreacion = DateTime.UtcNow;
            FechaActualizacion = DateTime.UtcNow;
            CreadoPor = creadoPor;
            
        }
        public void Update(
      string tipoDocumento,
      string numeroDoc,
      string razonSocial,
      string? nombreContacto,
      string? email,
      string? telefono,
      string? direccion,
      string tipo,
      int? actualizadoPor)
        {
            if (string.IsNullOrWhiteSpace(numeroDoc))
                throw new ArgumentException("El número de documento no puede estar vacío");

            if (string.IsNullOrWhiteSpace(razonSocial))
                throw new ArgumentException("La razón social no puede estar vacía");

            TipoDocumento = tipoDocumento;
            NumeroDoc = numeroDoc;
            RazonSocial = razonSocial;
            NombreContacto = nombreContacto;
            Email = email;
            Telefono = telefono;
            Direccion = direccion;
            Tipo = tipo;
            ActualizadoPor = actualizadoPor;
            FechaActualizacion = DateTime.UtcNow;
        }

        public void ChangeStatus(int? actualizadoPor)
        {
            Activo = !Activo;
            ActualizadoPor = actualizadoPor;
            FechaActualizacion = DateTime.UtcNow;
        }


        public static class TiposDocumento
        {
            public const string NIT = "NIT";
            public const string DPI = "DPI";
            public const string DNI = "DNI";
            public const string CE = "CE";
            public const string PASAPORTE = "PASAPORTE";
            public const string OTRO = "OTRO";

            public static readonly string[] Validos =
                { NIT, DPI, DNI, CE, PASAPORTE, OTRO };
        }

        public static class TiposCliente
        {
            public const string PERSONA_NATURAL = "PERSONA_NATURAL";
            public const string EMPRESA = "EMPRESA";

            public static readonly string[] Validos =
                { PERSONA_NATURAL, EMPRESA };
        }

    }
}
