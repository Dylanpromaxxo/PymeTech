using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PymeTech.Domain.Entities;

namespace PymeTech.Infrastructure.Persistence.Configurations
{
    public class CompraConfiguration : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {

            builder.ToTable("Compra");

            builder.HasKey(k => k.IdCompra).HasName("PK_Compra_IdCompra");

            builder.Property(p => p.IdTenant).HasColumnType("int").IsRequired();
            builder.Property(p => p.IdProveedor).HasColumnType("int").IsRequired();

            builder.Property(p => p.IdAlmacen)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.IdUsuario)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.NumeroDocumento)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.NumeroFacturaProv)
                .HasColumnType("varchar(40)")
                .IsRequired(false);

            builder.Property(p => p.TipoDocumento)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.FechaEmision)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(p => p.FechaRecepcion)
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.Property(p => p.Estado)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(p => p.SubTotal)
                .HasColumnType("decimal(14,2)")
                .IsRequired();

            builder.Property(p => p.TotalDescuento)
                .HasColumnType("decimal(14,2)")
                .IsRequired();

            builder.Property(p => p.TotalIva)
                .HasColumnType("decimal(14,2)")
                .IsRequired();

            builder.Property(p => p.Total)
                .HasColumnType("decimal(14,2)")
                .IsRequired();

            builder.Property(p => p.MonedaISO)
                .HasColumnType("char(3)")
                .IsRequired();

            builder.Property(p => p.TipoCambio)
                .HasColumnType("decimal(10,4)")
                .IsRequired();

            builder.Property(p => p.Notas)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            builder.Property(p => p.FechaCreacion)
                .HasColumnType("datetime2")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.FechaActualizacion)
                .HasColumnType("datetime2")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.CreadoPor)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.ActualizadoPor)
                .HasColumnType("int")
                .IsRequired(false);

            // Relaciones
            builder.HasOne(c => c.Tenant)
                .WithMany()
                .HasForeignKey(fk => fk.IdTenant)
                .HasConstraintName("FK_Compra_Tenant")
                .OnDelete(DeleteBehavior.Restrict); ;

            builder.HasOne(c => c.Proveedor)
                .WithMany(c => c.Compras)
                .HasForeignKey(fk => fk.IdProveedor)
                .HasConstraintName("FK_Compra_Proveedor");

            builder.HasOne(c => c.Almacen)
                .WithMany(x => x.Compras)
                .HasForeignKey(fk =>  fk.IdAlmacen )
                .HasConstraintName("FK_Compra_Almacen");

            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(fk => fk.IdUsuario )
                .HasConstraintName("FK_Compra_Usuario");

            builder.HasOne(c => c.CreadorCompra)
                .WithMany(u => u.ComprasCreadas)
                .HasForeignKey(fk => fk.CreadoPor)
                .HasConstraintName("FK_Compra_Creado");

            builder.HasOne(c => c.ActualizadorCompra)
                .WithMany(u => u.ComprasActualizadas)
                .HasForeignKey(fk => fk.ActualizadoPor)
                .HasConstraintName("FK_Compra_Actualizado");

            // indice único: no puede haber dos compras con el mismo número de documento en el mismo tenant
            builder.HasIndex(u => new { u.IdTenant, u.NumeroDocumento })
                .IsUnique()
                .HasDatabaseName("UQ_Compra_NumDoc");
            builder.HasIndex(x => new { x.IdTenant, x.IdCompra }).IsUnique();


            builder.HasIndex(x => new { x.IdTenant });
            builder.HasIndex(x => new { x.IdTenant, x.IdProveedor });
            builder.HasIndex(x => new { x.IdTenant, x.FechaEmision });
            builder.HasIndex(x => new { x.IdTenant, x.IdCompra });
        }
    }
}