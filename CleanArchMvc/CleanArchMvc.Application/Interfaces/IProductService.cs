using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    /// <summary>
    /// The product service.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns>A Task.</returns>
        Task<IEnumerable<ProductDTO>> GetProducts();
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        Task<ProductDTO> GetById(int? id);

        /// <summary>
        /// Adds the.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        /// <returns>A Task.</returns>
        Task Add(ProductDTO productDto);
        /// <summary>
        /// Updates the.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        /// <returns>A Task.</returns>
        Task Update(ProductDTO productDto);
        /// <summary>
        /// Removes the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        Task Remove(int? id);
    }
}
