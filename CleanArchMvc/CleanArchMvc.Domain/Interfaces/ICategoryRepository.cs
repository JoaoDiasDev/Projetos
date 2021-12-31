using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    /// <summary>
    /// The category repository.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>A Task.</returns>
        Task<IEnumerable<Category>> GetCategories();
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        Task<Category> GetById(int? id);

        /// <summary>
        /// Creates the.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>A Task.</returns>
        Task<Category> Create(Category category);
        /// <summary>
        /// Updates the.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>A Task.</returns>
        Task<Category> Update(Category category);
        /// <summary>
        /// Removes the.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>A Task.</returns>
        Task<Category> Remove(Category category);
    }
}
