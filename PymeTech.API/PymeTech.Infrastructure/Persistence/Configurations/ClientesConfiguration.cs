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
    public class ClientesConfiguration : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.IdCliente);

            builder.Property(c => c.IdTenant).IsRequired();
            builder.Property(c => c.TipoDocumento).IsRequired().HasMaxLength(10);
            builder.Property(c => c.NumeroDoc).HasColumnType("varchar").IsRequired().HasMaxLength(20);
            builder.Property(c => c.RazonSocial).HasColumnType("varchar").HasMaxLength(120);
            builder.Property(c => c.NombreContacto).HasColumnType("varchar").HasMaxLength(80);
            builder.Property(c => c.Email).HasColumnType("varchar").HasMaxLength(150);
            builder.Property(c => c.Telefono).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(c => c.Direccion).HasColumnType("varchar").HasMaxLength(200);
            builder.Property(c => c.Tipo).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(c => c.Activo);
            builder.Property(c => c.FechaCreacion).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.FechaActualizacion).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.CreadoPor).HasColumnType("Int");
            builder.Property(c => c.ActualizadoPor).HasColumnType("Int");


            builder.HasOne(x => x.Tenant)
                .WithMany()
                .HasForeignKey(x => x.IdTenant)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CreadorClientes)
               .WithMany(x => x.ClientesCreados)
               .HasForeignKey(x => x.CreadoPor)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ActualizadorClientes)
                .WithMany(x => x.ClientesActulizados)
                .HasForeignKey(x => x.ActualizadoPor)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(x => new { x.IdTenant, x.TipoDocumento, x.NumeroDoc }).IsUnique();
            builder.HasIndex(x => new { x.IdTenant, x.IdCliente }).IsUnique();

            builder.HasIndex(x => x.IdTenant);



        }

    }
}
