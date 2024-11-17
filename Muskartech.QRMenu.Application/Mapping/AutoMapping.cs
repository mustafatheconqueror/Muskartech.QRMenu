using AutoMapper;
using Muskartech.QRMenu.Application.Mapping.Resolver;

namespace Muskartech.QRMenu.Application.Mapping;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Domain.Aggregates.CategoryAggregate.Category, Features.Queries.Category.GetCategoryByIdViewModel>()
            .ReverseMap();
        
        
        CreateMap<Domain.Aggregates.ProductAggregate.Product, Features.Queries.Product.GetProductByIdViewModel>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom<MoneyToDecimalResolver>());

    }
}