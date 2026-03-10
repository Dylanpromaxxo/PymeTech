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
    public class RolPermisoConfiguration : IEntityTypeConfiguration<RolPermiso>
    {
        public void Configure(EntityTypeBuilder<RolPermiso> builder)
        {
            builder.ToTable("RolPermiso");

            builder.HasKey(x => new { x.IdTenant, x.IdRol, x.IdPermiso });

            builder.Property(x=> x.IdTenant).HasColumnType("int").IsRequired(); 
            builder.Property(x=> x.IdRol).HasColumnType("int").IsRequired();
            builder.Property(x=> x.IdPermiso).HasColumnType("int").IsRequired();
                builder.Property(x=> x.FechaAsignado).HasColumnType("datetime").IsRequired();
            builder.Property(x=> x.AsignadoPor).HasColumnType("int").IsRequired();

            // relaciones 

                builder.HasOne(x => x.Tenant)
                    .WithMany()
                    .HasForeignKey(x => x.IdTenant)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x => x.Rol)
                    .WithMany(x=> x.RolPermisos)
                    .HasForeignKey(x => x.IdRol)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x=>x.Permiso)
                    .WithMany(x=> x.RolPermisos)
                    .HasForeignKey(x => x.IdPermiso)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x=> x.UsuarioAsignado)
                    .WithMany(x=> x.PermisosAsignados)
                    .HasForeignKey(x => x.AsignadoPor)
                    .OnDelete(DeleteBehavior.Restrict);


        }
    }
}