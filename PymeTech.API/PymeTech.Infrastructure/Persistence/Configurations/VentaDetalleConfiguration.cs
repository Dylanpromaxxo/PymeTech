using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
using PymeTech.Domain.Entities; 


namespace PymeTech.Infrastructure.Persistence.Configurations
{
    public class VentaDetalleConfiguration : IEntityTypeConfiguration<VentaDetalle>
    {
        public void Configure(EntityTypeBuilder<VentaDetalle> builder)
        {
            builder.ToTable("VentaDetalle"); 

            builder.HasKey(vd => vd.IdVentaDetalle);
            builder.Property(p=> p.IdTenant).IsRequired().HasColumnType("int");
            builder.Property(p => p.IdVenta).IsRequired().HasColumnType("int");
            builder.Property(p => p.IdProducto).IsRequired().HasColumnType("int");
            builder.Property(p => p.Cantidad).IsRequired().HasColumnType("numeric(12,3)");
        }
    }
}
