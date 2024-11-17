using AutoMapper;
using MediatR;
using Muskartech.QRMenu.Application.Features.Queries.Product;
using Muskartech.QRMenu.Domain.Interfaces;

namespace Muskartech.QRMenu.Application.Features.Queries.Category;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdViewModel>
{
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetProductByIdViewModel> Handle(GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var category = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<GetProductByIdViewModel>(category);
    }
}