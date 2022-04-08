using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Queries
{
    /// <summary>
    /// The get product by id query.
    /// </summary>
    public class GetProductByIdQuery : IRequest<Product>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
