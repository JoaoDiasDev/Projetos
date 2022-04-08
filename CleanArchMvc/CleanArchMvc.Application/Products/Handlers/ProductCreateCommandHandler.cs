using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Handlers
{
    /// <summary>
    /// The product create command handler.
    /// </summary>
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCreateCommandHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        /// <summary>
        /// Handles the.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task.</returns>
        public Task<Product> Handle(ProductCreateCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price,
                              request.Stock, request.Image);

            if (product == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                product.CategoryId = request.CategoryId;
                return _productRepository.CreateAsync(product);
            }
        }
    }
}
