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
    public  class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
         {
            builder.ToTable("Tenant");
             builder.HasKey(t => t.IdTenant);
             builder.Property(t => t.Nombre).IsRequired().HasMaxLength(100);
             builder.Property(t => t.Email).IsRequired().HasMaxLength(150);
             builder.Property(t => t.Telefono).HasMaxLength(20);
             builder.Property(t => t.PlanSuscripcion).IsRequired().HasMaxLength(20);
             builder.Property(t => t.FechaCreacion).IsRequired();
             builder.Property(t => t.Activo).IsRequired();

            builder.HasIndex(t => t.Email).IsUnique();


            
        }
    
    }
}
