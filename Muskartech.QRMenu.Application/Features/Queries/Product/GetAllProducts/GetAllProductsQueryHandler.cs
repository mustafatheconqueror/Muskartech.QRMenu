using AutoMapper;
using MediatR;
using Muskartech.QRMenu.Domain.Interfaces;

namespace Muskartech.QRMenu.Application.Features.Queries.Product.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsViewModel>
{
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetAllProductsViewModel> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await _productRepository.GetAllAsync(cancellationToken);

        var productsViewModels = _mapper.Map<List<GetProductByIdViewModel>>(categories);

        return new GetAllProductsViewModel
        {
            Products = productsViewModels
        };
    }
}