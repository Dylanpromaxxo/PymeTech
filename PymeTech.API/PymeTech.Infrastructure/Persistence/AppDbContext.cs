using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PymeTech.Domain.Entities;

namespace PymeTech.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolPermiso> RolPermisos { get; set; }
        public DbSet<Permisos> Permisos { get; set; }   
        public DbSet<Clientes> Clientes { get; set; } 
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Almacenes> Almacenes { get; set; }
        public DbSet<Productos> Productos { get; set; } 
        public DbSet<Inventario> Inventarios { get; set; } 
        public DbSet<MovimientosInventario> MovimientosInventarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; } 
        public DbSet<Compra> Compras { get; set; } 
        public DbSet<CompraDetalle> CompraDetalles { get; set; } 




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            var now = DateTime.UtcNow;

            foreach (var entry in entries)  
            {
                var entity = entry.Entity;
                var type = entity.GetType();

                // FechaActualizacion for both Added and Modified
                var propActualizacion = type.GetProperty("FechaActualizacion", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (propActualizacion != null)
                {
                    var setMethod = propActualizacion.GetSetMethod(true);
                    if (setMethod != null)
                    {
                        setMethod.Invoke(entity, new object[] { now });
                    }
                }

                // FechaCreacion only for Added
                if (entry.State == EntityState.Added)
                {
                    var propCreacion = type.GetProperty("FechaCreacion", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (propCreacion != null)
                    {
                        var setMethod = propCreacion.GetSetMethod(true);
                        if (setMethod != null)
                        {
                            setMethod.Invoke(entity, new object[] { now });
                        }
                    }
                }
            }
        }
    }
}
