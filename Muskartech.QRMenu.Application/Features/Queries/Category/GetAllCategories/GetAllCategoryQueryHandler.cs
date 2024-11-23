using AutoMapper;
using MediatR;
using Muskartech.QRMenu.Application.Features.Queries.Category.GetAllCategory;
using Muskartech.QRMenu.Domain.Interfaces;

namespace Muskartech.QRMenu.Application.Features.Queries.Category.GetAllCategories;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, GetAllCategoryViewModel>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<GetAllCategoryViewModel> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);

        var categoryViewModels = _mapper.Map<List<GetCategoryByIdViewModel>>(categories);

        return new GetAllCategoryViewModel
        {
            Categories = categoryViewModels
        };
    }
}