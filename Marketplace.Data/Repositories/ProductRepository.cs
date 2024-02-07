using Marketplace.Core.Entities;
using Marketplace.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Product> AddAsync(Product product)
        {
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int productId)
        {
            var product = await GetByIdAsync(productId);
            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dataContext.Products.Include(p => p.Categories).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _dataContext.Products.Include(p => p.Categories).FirstAsync(p => p.Id == productId);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var existProduct = await GetByIdAsync(product.Id);
            _dataContext.Entry(existProduct).CurrentValues.SetValues(product);
            await _dataContext.SaveChangesAsync();
            return product;//TODO check which product to return!
        }
    }
}
