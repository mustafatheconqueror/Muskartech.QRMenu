using AutoMapper;
using MediatR;
using Muskartech.QRMenu.Application.Features.Queries.Category.GetCategoryById;
using Muskartech.QRMenu.Domain.Interfaces;

namespace Muskartech.QRMenu.Application.Features.Queries.Category;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdViewModel>
{
    private readonly ICategoryRepository _categoryRepository;

    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<GetCategoryByIdViewModel> Handle(GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<GetCategoryByIdViewModel>(category);
    }
}