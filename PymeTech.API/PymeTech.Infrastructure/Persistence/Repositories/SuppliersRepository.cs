using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Common.Models;
using PymeTech.Application.Feature.suppliers.SuppliersDTOs;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure.Persistence.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly AppDbContext _context;
        public SuppliersRepository(AppDbContext context)
        {
            _context = context; 
        }

        public async Task Create(Proveedores provedores, CancellationToken ct)
        {
            await _context.Proveedores.AddAsync(provedores, ct);
        }

       

        public async Task<PagedResult<SupplerSummaryDTO>> GetAllPageedAsync(int IdTenat, int pageNumber, int pageSize, CancellationToken ct)
        {
            var query = _context.Proveedores.AsNoTracking().Where(p => p.IdTenant == IdTenat);
            var totalRecords = await query.CountAsync(ct);

            var items = await query.OrderBy(p => p.RazonSocial)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new SupplerSummaryDTO
                {
                    IdProveedor = p.IdProveedor , 
                    IdTenant = p.IdTenant , 
                    Email = p.Email  , 
                    NombreContacto = p.NombreContacto , 
                    RazonSocial = p.RazonSocial,
                    Activo = p.Activo 

                }).ToListAsync();


            return new PagedResult<SupplerSummaryDTO>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
                Items = items

            };


        }

        public async Task<Proveedores> GetByIdAsync(int idTenant, int IdSupplier, CancellationToken ct)
        {
            return await _context.Proveedores.Where(p => p.IdTenant == idTenant && p.IdProveedor == IdSupplier).FirstOrDefaultAsync();
        }

        public async Task<PagedResult<SupplerSummaryDTO>> GetPagedAsync(int idTenant, int pageNumber, int pageSize, string? search, bool? activo, CancellationToken ct)
        {
            var query = _context.Proveedores.AsNoTracking().Where(p => p.IdTenant == idTenant); 

            if (activo.HasValue)
            {
                query = query.Where(p => p.Activo == activo.Value);
            }
            if(!string.IsNullOrEmpty(search))
            {
                var searchValue = search.ToLower().Trim(); 
                query = query.Where(p=> p.RazonSocial.ToLower().Contains(searchValue)
                || (p.NombreContacto != null && p.NombreContacto.ToLower().Contains(searchValue))
                || (p.NumeroDoc != null && p.NumeroDoc.ToLower().Contains(searchValue)));            
            }

            var totalRecords = await query.CountAsync(ct);
            var items = await query.OrderBy(c => c.RazonSocial)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new SupplerSummaryDTO
                {
                    IdProveedor = c.IdProveedor, 
                    IdTenant = c.IdTenant , 
                    Email = c.Email , 
                    NombreContacto = c.NombreContacto  ,
                    Activo = c.Activo

                }).ToListAsync();


            return new PagedResult<SupplerSummaryDTO>
            {
                PageNumber = pageNumber , 
                PageSize = pageNumber , 
                TotalRecords = totalRecords , 
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize), 
                Items = items 
               
            };




        }

        public async Task Update(Proveedores provedores, CancellationToken ct)
        {
             _context.Proveedores.Update(provedores);
        }
    }
}
