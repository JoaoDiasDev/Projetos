using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    /// <summary>
    /// The product repository.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _productContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        /// <summary>
        /// Creates the async.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>A Task.</returns>
        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        /// <summary>
        /// Gets the by id async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task<Product> GetByIdAsync(int? id)
        {
            return _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Gets the products async.
        /// </summary>
        /// <returns>A Task.</returns>
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        /// <summary>
        /// Removes the async.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>A Task.</returns>
        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        /// <summary>
        /// Updates the async.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>A Task.</returns>
        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
