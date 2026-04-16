
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PymeTech.Domain.Entities;

namespace PymeTech.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
           builder.ToTable("Usuario");
              builder.HasKey(u => u.IdUsuario);
              builder.Property(x=> x.IdTenant).HasColumnType("int").IsRequired();
              builder.Property(x=> x.IdRol).HasColumnType("int").IsRequired();
            builder.Property(u=> u.Email).HasMaxLength(150).IsRequired();
            builder.Property(u=> u.Nombre).HasMaxLength(80).IsRequired();
            builder.Property(u=> u.Apellido).HasMaxLength(80).IsRequired();
            builder.Property(u=> u.PasswordHash).HasMaxLength(200).IsRequired();
            builder.Property(u => u.Activo).HasDefaultValue(true);
            builder.Property(u => u.FechaCreacion).IsRequired();
            builder.Property(u => u.FechaActualizacion).IsRequired();
            builder.Property(u=> u.UltimoLogin).HasColumnType("DateTimeOffset").IsRequired(false);

            builder.HasIndex(u => new { u.IdTenant , u.Email  }).IsUnique();

            //relaciones estas relaciones hacen referencia a la tabla real de la base de datos, no a las propiedades de navegación en las entidades


            builder.HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.IdRol)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Usuario_Rol");

            builder.HasOne(u => u.Tenant)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(u => u.IdTenant)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
