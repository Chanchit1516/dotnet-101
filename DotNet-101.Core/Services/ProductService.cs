﻿using DotNet_101.Core.Entities;
using DotNet_101.Core.Interfaces;
using DotNet_101.Core.Interfaces.Repository;
using DotNet_101.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_101.Core.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllProduct();
        }

    }
}