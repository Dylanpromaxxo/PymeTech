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
    internal class CompraDetalleConfiguration : IEntityTypeConfiguration<CompraDetalle>
    {
        public void Configure(EntityTypeBuilder<CompraDetalle> builder)
        {
            builder.ToTable("CompraDetalle");

            builder.HasKey(k => k.IdCompraDetalle);

            builder.Property(p => p.IdTenant).HasColumnType("int").IsRequired();
            builder.Property(p => p.IdCompra).HasColumnType("int").IsRequired();
            builder.Property(p => p.IdProducto).HasColumnType("int").IsRequired();
            builder.Property(p => p.CantidadPedida).HasColumnType("numeric(12,3)").IsRequired();
            builder.Property(p => p.CantidadRecibida).HasColumnType("numeric(12,3)").IsRequired();
            builder.Property(p => p.PrecioUnitario).HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(p => p.PorcentajeDto).HasColumnType("decimal(5,2)").IsRequired();
            builder.Property(p => p.MontoDescuento).HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(p => p.PorcentajeIva).HasColumnType("decimal(5,2)").IsRequired();
            builder.Property(p => p.MontoIva).HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(p => p.SubTotal).HasColumnType("decimal(14,2)").IsRequired();
            builder.Property(p => p.Total).HasColumnType("decimal(14,2)").IsRequired();
            builder.Property(p => p.Notas).HasColumnType("varchar(300)").IsRequired(false);

            // Relaciones
            builder.HasOne(c => c.Tenant).WithMany().HasForeignKey(fk => fk.IdTenant).HasConstraintName("FK_CompraDetalle_Tenant");
            builder.HasOne(c => c.Compra).WithMany().HasForeignKey(fk => fk.IdCompra).HasConstraintName("FK_CompraDetalle_Compra");
            builder.HasOne(c => c.Producto).WithMany().HasForeignKey(fk => fk.IdProducto).HasConstraintName("FK_CompraDetalle_Producto");

            // Indices
            builder.HasIndex(p => new { p.IdTenant, p.IdCompra })
                .HasDatabaseName("UQ_CompraDetalle_Compra");

            builder.HasIndex(p => p.IdProducto)
                .HasDatabaseName("UQ_CompraDetalle_Producto");
        }
    }
}