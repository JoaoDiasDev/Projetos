using CleanArchMvc.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchMvc.Application.Products.Queries
{
    /// <summary>
    /// The get products query.
    /// </summary>
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
