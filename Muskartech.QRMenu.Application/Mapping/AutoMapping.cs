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


        CreateMap<Domain.Aggregates.RestaurantAggregate.Restaurant,
                Features.Queries.Restaurant.GetRestaurantByIdViewModel>()
            .ReverseMap();

        CreateMap<Domain.Aggregates.RestaurantAggregate.Table, Features.Queries.Restaurant.TableViewModel>()
            .ReverseMap();

        CreateMap<Domain.ValueObjects.ContactInfo, Features.Queries.Restaurant.ContactInfoViewModel>()
            .ReverseMap();


        CreateMap<Domain.Aggregates.ReservationAggregate.Reservation,
                Features.Queries.Reservation.GetReservationByIdViewModel>()
            .ReverseMap();


        CreateMap<Domain.ValueObjects.Customer,
                Features.Queries.Reservation.CustomerViewModel>()
            .ReverseMap();
    }
}