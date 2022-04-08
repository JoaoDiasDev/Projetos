using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands
{
    /// <summary>
    /// The product remove command.
    /// </summary>
    public class ProductRemoveCommand : IRequest<Product>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRemoveCommand"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
