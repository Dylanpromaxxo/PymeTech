using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore.Storage;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context; 
        private  IDbContextTransaction _transaction;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync(CancellationToken ct)
        {
            _transaction = await _context.Database.BeginTransactionAsync(ct);
        }

        public async Task CommitAsync(CancellationToken ct)
        {
            try 
            {
                await _context.SaveChangesAsync(ct);
                await _transaction.CommitAsync(ct);
            }
            finally 
            {
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollBackAsync(CancellationToken ct)
        {
            try
            {
                await _transaction.RollbackAsync(ct); 
            }
            finally 
            {
                await _transaction.DisposeAsync(); 
            }
        }

        public async Task SaveAsync(CancellationToken ct)
        {
           await _context.SaveChangesAsync(ct);
        }
    }
}
