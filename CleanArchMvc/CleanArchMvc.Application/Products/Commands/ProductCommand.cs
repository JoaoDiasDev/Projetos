using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands
{
    /// <summary>
    /// The product command.
    /// </summary>
    public abstract class ProductCommand : IRequest<Product>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        public int Stock { get; set; }
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public int CategoryId { get; set; }
    }
}
