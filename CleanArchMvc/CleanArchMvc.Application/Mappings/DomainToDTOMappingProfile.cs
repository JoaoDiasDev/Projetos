using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings
{
    /// <summary>
    /// The domain to d t o mapping profile.
    /// </summary>
    public class DomainToDTOMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToDTOMappingProfile"/> class.
        /// </summary>
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
