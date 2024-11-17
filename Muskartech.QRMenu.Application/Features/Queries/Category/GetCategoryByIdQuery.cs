using MediatR;

namespace Muskartech.QRMenu.Application.Features.Queries.Category;

public class GetCategoryByIdQuery : IRequest<GetCategoryByIdViewModel>
{
    public string Id { get; set; }
}