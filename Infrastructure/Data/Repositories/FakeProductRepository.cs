﻿using Core.Dto.RepositoryResponses.ProductRepository;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product> {
                    new Product
                    {
                        Name = "Kayak",
                        Description = "А boat for one person",
                        Category = "Watersports",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionaЫe",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field а professional touch",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35, 000-seat stadium",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Thinking Сар",
                        Description = "Improve brain efficiency Ьу 75i",
                        Category = "Chess",
                        Price = 16
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent а disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Description = "А fun game for the family",
                        Category = "Chess",
                        Price = 75
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200
                    }
        }.AsQueryable<Product>();

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsByPaginationAndCategory(int page, int pageSize, string category)
        {
            return await Task.FromResult(Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList());
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await Task.FromResult(Products.FirstOrDefault(f => f.Id == productId));
        }

        public async Task<int> CountProductsByCategory(string category)
        {
            return await Task.FromResult(Products
               .Where(w => category == null || w.Category == category)
                .Count());
        }

        public Task<CreateProductResponse> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteProductResponse> Delete(Product product)
        {
            throw new NotImplementedException();
        }                     

        public Task<UpdateProductResponse> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
