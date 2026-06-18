using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Customer.CustomerDTOs
{
    public class CustomerDTO
    {
        public int IdCliente { get; init; }
        public string TipoDocumento { get; init; }
        public string NumeroDoc { get; init; }
        public string RazonSocial { get; init; }
        public string NombreContacto { get; init; }
        public string Email { get; init; }
        public string Telefono { get; init; }
        public string Direccion { get; init; }
        public string Tipo { get; init; }
        public bool Activo { get; init; }
        public DateTime FechaCreacion { get; init; }
    }
}
