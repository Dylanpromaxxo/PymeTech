using Microsoft.EntityFrameworkCore;
using PymeTech.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Principal;

namespace PymeTech.Infrastructure.Persistence.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {

            builder.ToTable("Roles");

            builder.HasKey(r => r.IdRol);
            builder.Property(x => x.IdTenant).HasColumnType("int").IsRequired();
            builder.Property(x=> x.NombreRol).HasColumnType("varchar(100)").IsRequired(); 
            builder.Property(x=> x.Descripcion).HasColumnType("varchar(255)").IsRequired(false);
            builder.Property(x=> x.Activo).HasColumnType("bit").HasDefaultValue(true);
            builder.Property(x=> x.FechaCreacion).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");


            builder.HasIndex(r => new { r.IdTenant, r.NombreRol });

            builder.HasOne(r => r.Tenant)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.IdTenant)
                .OnDelete(DeleteBehavior.Restrict);

            

        }
    }
}
