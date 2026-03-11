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
    public class PermisosConfiguration : IEntityTypeConfiguration<Permisos>
    {
        public void Configure(EntityTypeBuilder<Permisos> builder)
        {
            builder.ToTable("Permisos");
            builder.HasKey(x => x.IdPermiso);
            builder.Property(x=> x.Modulo).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Accion).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.Descripcion).HasColumnType("varchar(200)").IsRequired(false);

            builder.HasIndex(x => new { x.Modulo, x.Accion }).IsUnique();


        }
    }
}
