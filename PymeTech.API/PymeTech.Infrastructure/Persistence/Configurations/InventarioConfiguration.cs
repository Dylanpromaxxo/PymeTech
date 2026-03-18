using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using PymeTech.Domain.Entities;

namespace PymeTech.Infrastructure.Persistence.Configurations
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventario");

            builder.HasKey(i => i.IdInventario);
            builder.Property(i => i.IdTenant).IsRequired();
            builder.Property(i => i.IdProducto).IsRequired();
            builder.Property(i => i.IdAlmacen).IsRequired();
            builder.Property(i => i.StockActual).HasColumnType("decimal(12,3)").IsRequired();
            builder.Property(i => i.StockMinimo).HasColumnType("decimal(12,3)").IsRequired();
            builder.Property(i => i.StockMaximo).HasColumnType("decimal(12,3)");
            builder.Property(i => i.FechaActualizacion).IsRequired().HasDefaultValueSql("GetDate()");

            builder.HasOne(i => i.Tenant)
                   .WithMany()
                   .HasForeignKey(i => i.IdTenant)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Inv_Tenant");

            builder.HasOne(i => i.Producto)
                .WithMany(i => i.Inventarios)
                .HasForeignKey(i => i.IdProducto)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Inv_Producto");

            builder.HasOne(i => i.Almacen)
                .WithMany(i => i.Inventarios)
                .HasForeignKey(i =>  i.IdAlmacen )
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Inv_Almacen");

            builder.HasIndex(x => new { x.IdTenant, x.IdProducto, x.IdAlmacen }).IsUnique();

            builder.HasIndex(x => new { x.IdTenant, x.IdProducto });
            builder.HasIndex(x => new { x.IdTenant, x.IdAlmacen });

        }

    }
}
