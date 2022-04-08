using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings
{
    /// <summary>
    /// The d t o to command mapping profile.
    /// </summary>
    public class DTOToCommandMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DTOToCommandMappingProfile"/> class.
        /// </summary>
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();
        }
    }
}
