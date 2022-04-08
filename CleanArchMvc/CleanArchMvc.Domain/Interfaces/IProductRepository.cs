using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    /// <summary>
    /// The product repository.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets the products async.
        /// </summary>
        /// <returns>A Task.</returns>
        Task<IEnumerable<Product>> GetProductsAsync();
        /// <summary>
        /// Gets the by id async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        Task<Product> GetByIdAsync(int? id);


        /// <summary>
        /// Creates the async.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>A Task.</returns>
        Task<Product> CreateAsync(Product product);
        /// <summary>
        /// Updates the async.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>A Task.</returns>
        Task<Product> UpdateAsync(Product product);
        /// <summary>
        /// Removes the async.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>A Task.</returns>
        Task<Product> RemoveAsync(Product product);
    }
}
