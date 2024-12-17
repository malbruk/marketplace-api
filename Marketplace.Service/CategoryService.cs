using Marketplace.Core.Entities;
using Marketplace.Core.Repositories;
using Marketplace.Core.Services;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Service
{
    public class CategoryService(IRepositoryManager repositoryManager) : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;


        public async Task<Category> AddAsync(Category category)
        {
            _repositoryManager.Categories.Add(category);
            await _repositoryManager.SaveAsync();
            return category;
        }

        public async Task DeleteAsync(int categoryId)
        {
            var category = await _repositoryManager.Categories.GetByIdAsync(categoryId);
            _repositoryManager.Categories.Delete(category);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _repositoryManager.Categories.GetListAsync();
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            return await _repositoryManager.Categories.GetByIdAsync(categoryId);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            //TODO get from dto and update properties
            _repositoryManager.Categories.Update(category);
            await _repositoryManager.SaveAsync();
            return category;
        }
    }
}
