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
    public class ProductosConfiguration : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
                builder.ToTable("Productos"); 

            builder.HasKey(p => p.IdProducto).HasName("PK_Productos"); 

           builder.Property(p=>p.)

        }
    }
}
