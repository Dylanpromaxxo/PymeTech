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
    public class AlmancenesConfiguration : IEntityTypeConfiguration<Almacenes>
    {
        public void Configure(EntityTypeBuilder<Almacenes> builder)
        {
            builder.ToTable("Almacenes");


            builder.HasKey(k => k.IdAlmacen).HasName("PK_Almacenes_IdAlmacen");

            builder.Property(p => p.IdTenant).HasColumnType("int").IsRequired();
            builder.Property(p => p.Nombre).HasColumnType("varchar(80)").IsRequired();
            builder.Property(p => p.Descripcion).HasColumnType("varchar(300)").IsRequired(false);
            builder.Property(p => p.EsPrincipal).HasColumnType("bit").IsRequired().HasDefaultValue(false);
            builder.Property(p => p.Activo).HasColumnType("bit").IsRequired().HasDefaultValue(true);
            builder.Property(p => p.FechaCreacion).HasColumnType("datetime2").IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.CreadoPor).HasColumnType("int");


            builder.HasOne(I => I.Tenant)
                .WithMany()
                .HasForeignKey(fk => fk.IdTenant)
                .HasConstraintName("FK_Almacenes_Tenant")
                .OnDelete(DeleteBehavior.Restrict); ;


            builder.HasOne(references => references.CreadorAlmacen)
                .WithMany(Referenciador => Referenciador.AlmacenesCreados)
                .HasForeignKey(foreignKey => foreignKey.CreadoPor)
                .HasConstraintName("FK_Almacenes_Creado")
                .OnDelete(DeleteBehavior.Restrict); ;


            builder.HasIndex(u => new { u.IdTenant, u.Nombre })
                .IsUnique()
                .HasDatabaseName("UQ_Almacenes_Nombre");


            builder.HasIndex(u => new { u.IdTenant, u.IdAlmacen })
                .IsUnique()
                .HasDatabaseName("UQ_Almacenes_Tenant");




        }
    }
}
