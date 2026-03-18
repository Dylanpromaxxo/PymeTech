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
            builder.Property(p => p.PrecioUnitario).IsRequired().HasColumnType("decimal(12,2)");
            builder.Property(p => p.PorcentajeDto).IsRequired().HasColumnType("decimal(5,2)");
            builder.Property(p => p.MontoDescuento).IsRequired().HasColumnType("decimal(12,2)");
            builder.Property(p => p.PorcentajeIva).IsRequired().HasColumnType("decimal(5,2)");
            builder.Property(p => p.MontoIva).IsRequired().HasColumnType("decimal(12,2)");
            builder.Property(p => p.Subtotal).IsRequired().HasColumnType("decimal(14,2)");
            builder.Property(p => p.Total).IsRequired().HasColumnType("decimal(14,2)");
                builder.Property(p => p.Notas).HasMaxLength(500).HasColumnType("varchar(500)");

                builder.HasOne(vd=> vd.tenant)
                        .WithMany()
                        .HasForeignKey(vd => vd.IdTenant)
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_VentaDet_Tenant")
                        ;


                builder.HasOne(vd => vd.venta)
                        .WithMany(v => v.VentaDetalles)
                        .HasForeignKey(vd => vd.IdVenta )
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_VentaDet_Venta")
                        ;
    
                        builder.HasOne(vd => vd.producto)
                            .WithMany(p => p.VentasDetalle)
                            .HasForeignKey(vd => vd.IdProducto)
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_VentaDet_Producto")
                        ;

            builder.HasIndex(x => new { x.IdTenant, x.IdVenta });

            builder.HasIndex(x => new { x.IdTenant, x.IdProducto });


                
        }
    }
}
