using AutoMapper;

namespace Catalog.API.Application.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TypeEntity, TypeModel>().ReverseMap();

        CreateMap<BrandEntity, BrandModel>().ReverseMap();

        CreateMap<ProductEntity, ProductModel>().ReverseMap()
              .ForMember(opt => opt.CreatedAt, opt => opt.Ignore())
            .ForMember(opt => opt.Type, opt => opt.Ignore())
            .ForMember(opt => opt.Brand, opt => opt.Ignore());

    }
}
