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
    public class ProveedoresConfiguration : IEntityTypeConfiguration<Proveedores>
    {
        public void Configure(EntityTypeBuilder<Proveedores> builder)
        {
            builder.ToTable("Proveedores");

            builder.HasKey(p => p.IdProveedor);
            builder.Property(p => p.IdTenant).IsRequired().HasColumnType("Int");
            builder.Property(p => p.TipoDocumento).IsRequired().HasMaxLength(10);
            builder.Property(p => p.NumeroDoc).IsRequired().HasMaxLength(20);
            builder.Property(p => p.RazonSocial).IsRequired().HasMaxLength(120);
            builder.Property(P => P.NombreContacto).HasMaxLength(80);
            builder.Property(p => p.Email).HasMaxLength(150);
            builder.Property(p => p.Telefono).HasMaxLength(20);
            builder.Property(p => p.Direccion).HasMaxLength(200);
            builder.Property(p => p.Activo).HasDefaultValue(true);
            builder.Property(p => p.FechaCreacion).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.FechaActualizacion).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.CreadoPor).HasColumnType("Int");
            builder.Property(p => p.ActualizadoPor).HasColumnType("Int");

            builder.HasOne(x => x.CreadorProveedor)
                .WithMany(x => x.ProveedoresCreados)
                .HasForeignKey(x => x.CreadoPor)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ActualizadorProveedor)
                .WithMany(x => x.ProveedoresActualizados)
                .HasForeignKey(x => x.ActualizadoPor)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Tenant)
                .WithMany()
                .HasForeignKey(x => x.IdTenant)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(p => new { p.IdTenant, p.NumeroDoc }).IsUnique();
            builder.HasIndex(p => new { p.IdTenant, p.IdProveedor }).IsUnique();


            builder.HasIndex(p => p.IdTenant);







        }
    }
}
