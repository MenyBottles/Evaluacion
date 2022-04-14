using Application.Products.Queries.GetProduct;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, GetProductDto>()
            .ForMember(o => o.StatusName, opt => opt.MapFrom(x => x.Status.StatusId.ToString()));
    }

}