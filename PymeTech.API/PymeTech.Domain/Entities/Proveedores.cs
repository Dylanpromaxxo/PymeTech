using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Domain.Entities
{
    public class Proveedores
    {
        public int IdProveedor { get; private set; }
        public int IdTenant { get; private set; }
        public string TipoDocumento { get; private set; }
        public string NumeroDoc { get; private set; }
        public string RazonSocial { get; private set; }
        public string NombreContacto { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public string Direccion { get; private set; }
        public bool Activo { get; private set; }

        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }

        public int? CreadoPor { get; private set; }
        public int? ActualizadoPor { get; private set; }

        // referencias a otras entidades del dominio 

        public Tenant Tenant { get; private set; }
        public Usuario CreadorProveedor { get; private set; }
        public Usuario ActualizadorProveedor { get; private set; }

        // Constructor privado para EF Core y para garantizar la integridad de la entidad a través del constructor público
        private Proveedores() { } 

        public Proveedores(int idTenant, string tipoDoc, string numeroDoc, string razonSocial, string nombreContacto, string email, string telefono, string direccion, int? creadoPor, int? actualizadoPor)
        {
            if (string.IsNullOrWhiteSpace(numeroDoc))
                throw new ArgumentException("El número de documento no puede estar vacío");
            if (string.IsNullOrWhiteSpace(razonSocial))
                throw new ArgumentException("La razón social no puede estar vacía");
            IdTenant = idTenant;
            TipoDocumento = tipoDoc;
            NumeroDoc = numeroDoc;
            RazonSocial = razonSocial;
            NombreContacto = nombreContacto;
            Email = email;
            Telefono = telefono;
            Direccion = direccion;
            Activo = true;
            FechaCreacion = DateTime.UtcNow;
            FechaActualizacion = DateTime.UtcNow;
            CreadoPor = creadoPor;
            ActualizadoPor = actualizadoPor;
        }



    }
}
