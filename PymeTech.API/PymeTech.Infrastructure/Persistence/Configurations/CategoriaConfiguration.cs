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
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(c => c.IdCategoria);
            builder.Property(c => c.IdTenant).IsRequired().HasColumnType("Int");
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(80);
            builder.Property(c => c.Descripcion).HasMaxLength(300);
            builder.Property(c => c.Activo).HasDefaultValue(true);
            builder.Property(c => c.FechaCreacion).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.FechaActualizacion).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.CreadoPor).HasColumnType("Int");


            builder.HasOne(c => c.Tenant)
                .WithMany()
                .HasForeignKey(c => c.IdTenant)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(c => c.CreadorCategoria)
                .WithMany(c => c.CategoriasCreadas)
                .HasForeignKey(c => c.CreadoPor)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => new { c.IdTenant, c.Nombre }).IsUnique();
            builder.HasIndex(c => new { c.IdTenant, c.IdCategoria }).IsUnique();
            builder.HasIndex(c => c.IdTenant);



        }

    }
}
