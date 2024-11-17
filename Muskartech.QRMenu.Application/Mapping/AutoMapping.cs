using AutoMapper;

namespace Muskartech.QRMenu.Application.Mapping;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Domain.Aggregates.CategoryAggregate.Category, Features.Queries.Category.GetCategoryByIdViewModel>()
            .ReverseMap();
    }
}