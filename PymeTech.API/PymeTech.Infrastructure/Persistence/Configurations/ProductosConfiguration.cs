using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PymeTech.Domain.Entities;

namespace PymeTech.Infrastructure.Persistence.Configurations
{
    public class ProductosConfiguration : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.ToTable("Productos");

            // PK
            builder.HasKey(p => p.IdProducto).HasName("PK_Productos");

            // Propiedades
            builder.Property(p => p.IdTenant).HasColumnType("int").IsRequired();
            builder.Property(p => p.IdCategoria).HasColumnType("int").IsRequired();
            builder.Property(p => p.Codigo).HasColumnType("varchar(30)").IsRequired();
            builder.Property(p => p.Nombre).HasColumnType("varchar(150)").IsRequired();
            builder.Property(p => p.Descripcion).HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(p => p.UnidadMedida).HasColumnType("varchar(10)").IsRequired();
            builder.Property(p => p.PrecioVenta).HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(p => p.PrecioCompra).HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(p => p.IvaIncluido).HasColumnType("bit").IsRequired();
            builder.Property(p => p.PorcentajeIva).HasColumnType("decimal(5,2)").IsRequired();
            builder.Property(p => p.EsServicio).HasColumnType("bit").IsRequired().HasDefaultValue(false);
            builder.Property(p => p.Activo).HasColumnType("bit").IsRequired().HasDefaultValue(true);
            builder.Property(p => p.FechaCreacion).HasColumnType("datetime2").IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.FechaActualizacion).HasColumnType("datetime2").IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.CreadoPor).HasColumnType("int").IsRequired(false);
            builder.Property(p => p.ActualizadoPor).HasColumnType("int").IsRequired(false);

            // Relaciones
            builder.HasOne(p => p.Tenant)
                .WithMany()
                .HasForeignKey(fk => fk.IdTenant)
                .HasConstraintName("FK_Productos_Tenant");

            builder.HasOne(p => p.Categoria)
                .WithMany(p=> p.Productos)
                .HasForeignKey(fk => fk.IdCategoria)
                .HasConstraintName("FK_Productos_Categoria");

            builder.HasOne(p => p.CreadorProducto)
                .WithMany(u => u.ProductosCreados)
                .HasForeignKey(fk => fk.CreadoPor)
                .HasConstraintName("FK_Productos_Creado");

            builder.HasOne(p => p.ActualizadorProducto)
                .WithMany(u => u.ProductosActualizados)
                .HasForeignKey(fk => fk.ActualizadoPor)
                .HasConstraintName("FK_Productos_Actualizado");

            // Índices
            builder.HasIndex(p => new { p.IdTenant, p.Codigo })
                .IsUnique()
                .HasDatabaseName("UQ_Productos_Codigo");

            builder.HasIndex(p => p.IdTenant)
                .HasDatabaseName("IX_Productos_Tenant");

            builder.HasIndex(p => p.IdCategoria)
                .HasDatabaseName("IX_Productos_Categoria");
        }
    }
}