﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_101.Core.Entities;
using DotNet_101.Core.Interfaces.Service;
using DotNet_101.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet_101.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        IProductService _productService;


        public ProductController(IProductService productService, ApplicationDbContext context)
        {
            _productService = productService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var result = _context.Products.ToList();
            //var result = (from p in _context.Orders
            //              join t in _context.OrderDetails on p.OrderId equals t.OrderId
            //              where p.OrderId == orderId
            //              select new { OrderDate = p.OrderDate, Qty = t.Qty }).ToList();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult InsertProduct()
        {
            var product = new Product();
            product.ProductName = "Pencil";
            product.UnitPrice = 10;
            product.UnitsInStock = 100;
            product.UpdatedBy = 1;
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();
        }


    }
}