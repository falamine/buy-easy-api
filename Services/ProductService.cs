using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buy_easy_api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace buy_easy_api.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProduct(int id);
        public Task<Product> CreateProduct(Product product);
        public Task<List<Product>> Search(string query);
    } 
    public class ProductService: IProductService
    {
        private readonly BuyEasyDbContext _dbContext;

        public ProductService(BuyEasyDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var newProduct = new Product
            {
                Name = product.Name, Brand = product.Brand, Price = product.Price,
                Quantity = product.Quantity, Type = product.Type
                
            };
            _dbContext.Products.Add(newProduct);
            await _dbContext.SaveChangesAsync();

            return newProduct;
        }

        public Task<List<Product>> Search(string query)
        {
            Task<List<Product>> products = null;
            if (!string.IsNullOrEmpty(query))
            {
                products =  _dbContext.Products.Where(p => p.Name.Contains(query)).ToListAsync();
            }

            return products;
        }
    }
}