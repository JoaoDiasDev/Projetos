using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    /// <summary>
    /// The category service.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>A Task.</returns>
        Task<IEnumerable<CategoryDTO>> GetCategories();
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        Task<CategoryDTO> GetById(int? id);
        /// <summary>
        /// Adds the.
        /// </summary>
        /// <param name="categoryDto">The category dto.</param>
        /// <returns>A Task.</returns>
        Task Add(CategoryDTO categoryDto);
        /// <summary>
        /// Updates the.
        /// </summary>
        /// <param name="categoryDto">The category dto.</param>
        /// <returns>A Task.</returns>
        Task Update(CategoryDTO categoryDto);
        /// <summary>
        /// Removes the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        Task Remove(int? id);

    }
}
