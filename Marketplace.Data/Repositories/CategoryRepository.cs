using Marketplace.Core.Entities;
using Marketplace.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Category> AddAsync(Category category)
        {
            _dataContext.Categories.Add(category);
            await _dataContext.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(int categoryId)
        {
            var category = await GetByIdAsync(categoryId);
            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dataContext.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            return await _dataContext.Categories.Include(c => c.Parent).FirstAsync(c => c.Id == categoryId);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var existCategory = await GetByIdAsync(category.Id);
            _dataContext.Entry(existCategory).CurrentValues.SetValues(existCategory);
            await _dataContext.SaveChangesAsync();
            return existCategory;
        }
    }
}
