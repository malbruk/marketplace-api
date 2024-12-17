using Marketplace.Core.Entities;
using Marketplace.Core.Repositories;
using Marketplace.Core.Services;
using Marketplace.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Service
{
    public class ProductService(IRepositoryManager repositoryManager) : IProductService
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;


        public async Task<Product> AddAsync(Product product)
        {
            product.Slug = product.Name.Slugify();
            _repositoryManager.Products.Add(product);
            await _repositoryManager.SaveAsync();
            return product;
        }

        public async Task DeleteAsync(int productId)
        {
            var product = await GetByIdAsync(productId);
            _repositoryManager.Products.Delete(product);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repositoryManager.Products.GetListAsync();
        }

        public Task<Product?> GetByIdAsync(int productId)
        {
            return _repositoryManager.Products.GetByIdAsync(productId);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            product.Slug = product.Name.Slugify();
            _repositoryManager.Products.Update(product);
            await _repositoryManager.SaveAsync();
            return product;
        }
    }
}
