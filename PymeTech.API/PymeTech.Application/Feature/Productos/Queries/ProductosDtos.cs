using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Application.Feature.Productos.Queries
{
    public record  ProductosDtos
    {
        int IdProducto;
        string NombreCategoria;
        string Codigo;
        string Nombre;
        string?  Descripcion;
        string UnidadMedida;
        decimal PrecioVenta;
        decimal PrecioCompra;
        bool IvaIncluido;
        decimal PorcentajeIva;
        bool EsServicio;
        bool Activo;
        DateTime FechadeCreacion; 


    }
}
