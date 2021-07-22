﻿using DotNet_101.Core.Interfaces.Repository;
using DotNet_101.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_101.Infrastructure.SqlServer
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;
        IProductRepository productRepository;
        ICustomerRepository customerRepository;
        //private readonly ILogger _logger;

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
        }

        public IProductRepository ProductRepository => productRepository ??= new ProductRepository(_context);
        public ICustomerRepository CustomerRepository => customerRepository ??= new CustomerRepository(_context);

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
