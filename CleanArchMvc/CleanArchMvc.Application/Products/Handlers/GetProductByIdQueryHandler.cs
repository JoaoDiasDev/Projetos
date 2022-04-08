using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Handlers
{
    /// <summary>
    /// The get product by id query handler.
    /// </summary>
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task.</returns>
        public Task<Product> Handle(GetProductByIdQuery request,
             CancellationToken cancellationToken)
        {
            return _productRepository.GetByIdAsync(request.Id);
        }
    }
}
