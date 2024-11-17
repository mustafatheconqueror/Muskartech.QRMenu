using AutoMapper;
using Muskartech.QRMenu.Application.Features.Queries.Product;
using Muskartech.QRMenu.Domain.Aggregates.ProductAggregate;

namespace Muskartech.QRMenu.Application.Mapping.Resolver;

public class MoneyToDecimalResolver : IValueResolver<Product, GetProductByIdViewModel, decimal>
{
    public decimal Resolve(Product source, GetProductByIdViewModel destination, decimal destMember,
        ResolutionContext context)
    {
        return source.Price?.Value ?? 0;
    }
}