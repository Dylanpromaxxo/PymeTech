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
    public class MovimientosInventarioConfiguration : IEntityTypeConfiguration<MovimientosInventario>
    {
        public void Configure(EntityTypeBuilder<MovimientosInventario> builder)
        {
            builder.ToTable("MovimientosInventario");

            builder.HasKey(m => m.IdMovimiento);
            builder.Property(m => m.IdTenant).HasColumnType("int").IsRequired();
            builder.Property(m => m.IdProducto).HasColumnType("int").IsRequired();
            builder.Property(m => m.IdAlmacen).HasColumnType("int").IsRequired();
            builder.Property(m => m.IdUsuario).HasColumnType("int").IsRequired();
            builder.Property(m => m.TipoMovimiento).HasColumnType("varchar(25)").IsRequired();
            builder.Property(m => m.Cantidad).HasColumnType("decimal(12,3)").IsRequired();
            builder.Property(m => m.StockAnterior).HasColumnType("decimal(12,3)").IsRequired();
            builder.Property(m => m.StockNuevo).HasColumnType("decimal(12,3)").IsRequired();
            builder.Property(m => m.ReferenciaTipo).HasColumnType("varchar(30)").IsRequired(false);
            builder.Property(m => m.ReferenciaId).HasColumnType("int").IsRequired(false);
            builder.Property(m => m.Notas).HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(m => m.FechaCreacion).HasColumnType("datetime2").IsRequired().HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.Tenant)
                .WithMany()
                .HasForeignKey(x => x.IdTenant)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MovInv_Tenant")
                ;

            builder.HasOne(x => x.Producto)
                .WithMany(x => x.MovimientosDeInventario)
                .HasForeignKey(x => x.IdProducto)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MovInv_Producto");

            builder.HasOne(x => x.Almacen)
                .WithMany(x => x.MovimientosInventario)
                .HasForeignKey(x => x.IdAlmacen)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MovInv_Almacen");

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MovInv_Usuario");


            builder.HasIndex(x => x.IdTenant);
            builder.HasIndex(x => new { x.IdTenant, x.IdProducto });
            builder.HasIndex(x => new { x.IdTenant, x.IdAlmacen });
            builder.HasIndex(x => new { x.IdTenant, x.FechaCreacion });



        }
    }
}
