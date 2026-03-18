using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using   PymeTech.Domain.Entities;

namespace PymeTech.Infrastructure.Persistence.Configurations
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Venta");
            
            builder.HasKey(x=> x.IdVenta);
            builder.Property(x=> x.IdTenant).HasColumnType("int").IsRequired();
            builder.Property(x=> x.IdCliente).HasColumnType("int").IsRequired();
            builder.Property(x=> x.IdAlmacen).HasColumnType("int").IsRequired();
            builder.Property(x=> x.IdUsuario).HasColumnType("int").IsRequired();
            builder.Property(x=> x.NumeroDocumento).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x=> x.TipoDocumento).HasColumnType("varchar(15)").IsRequired();
            builder.Property(x=> x.FechaEmision).HasColumnType("datetime2").IsRequired();
            builder.Property(x=> x.FechaVencimiento).HasColumnType("date").IsRequired(false);
            builder.Property(x=> x.Estado).HasColumnType("varchar(15)").IsRequired();
            builder.Property(x=> x.Subtotal).HasColumnType("decimal(14,2)").IsRequired().HasDefaultValue(0);
            builder.Property(x=> x.TotalDescuento).HasColumnType("decimal(14,2)").IsRequired().HasDefaultValue(0);
            builder.Property(x=> x.TotalIva).HasColumnType("decimal(14,2)").IsRequired().HasDefaultValue(0);
            builder.Property(x=> x.Total).HasColumnType("decimal(14,2)").IsRequired().HasDefaultValue(0);
            builder.Property(x=> x.MonedaISO).HasColumnType("char(3)").IsRequired();
            builder.Property(x=> x.TipoCambio).HasColumnType("decimal(10,4)").IsRequired().HasDefaultValue(1.0000);
            builder.Property(x=> x.Notas).HasColumnType("varchar(500)").IsRequired(false);
            builder.Property(x=> x.FechaCreacion).HasColumnType("datetime2").IsRequired();
            builder.Property(x=> x.FechaActualizacion).HasColumnType("datetime2").IsRequired();
            builder.Property(x=> x.CreadoPor).HasColumnType("int").IsRequired();
            builder.Property(x=> x.ActualizadoPor).HasColumnType("int").IsRequired(false);


            builder.HasOne(t=> t.Tenant)
                .WithMany()
                .HasForeignKey(t=> t.IdTenant)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Venta_Tenant");

            builder.HasOne(c=> c.Clientes)
                .WithMany(x=> x.Ventas)
                .HasForeignKey(f=> f.IdCliente )
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Venta_Clientes");

            builder.HasOne(a=> a.Almacen)
                .WithMany(x=> x.Ventas)
                .HasForeignKey(f=> f.IdAlmacen)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Venta_Almacen");

            builder.HasOne(u=> u.Usuario)
                .WithMany()
                .HasForeignKey(f=> f.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Venta_Usuario");

            builder.HasOne(u=> u.CreadorVenta)
                .WithMany()
                .HasForeignKey(f=> f.CreadoPor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Venta_CreadorVenta"); 
            
            builder.HasOne(u=> u.ActualizadorVenta)
                .WithMany()
                .HasForeignKey(f=> f.ActualizadoPor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Venta_ActualizadorVenta");

            builder.HasIndex(c => new { c.IdTenant, c.NumeroDocumento }).IsUnique();
            builder.HasIndex(c => new { c.IdTenant, c.IdVenta }).IsUnique();

            builder.HasIndex(c => c.IdTenant); 
            builder.HasIndex (c => new {c.IdTenant , c.IdCliente  });
            builder.HasIndex(c => new { c.IdTenant, c.FechaEmision });
            builder.HasIndex(c => new { c.IdTenant, c.Estado });
            





        }
    }
}
