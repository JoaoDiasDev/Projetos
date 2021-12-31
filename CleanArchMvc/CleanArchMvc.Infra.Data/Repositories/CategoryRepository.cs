using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    /// <summary>
    /// The category repository.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Creates the.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>A Task.</returns>
        public async Task<Category> Create(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public async Task<Category> GetById(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>A Task.</returns>
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        /// <summary>
        /// Removes the.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>A Task.</returns>
        public async Task<Category> Remove(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        /// <summary>
        /// Updates the.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>A Task.</returns>
        public async Task<Category> Update(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
