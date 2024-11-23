using MediatR;

namespace Muskartech.QRMenu.Application.Features.Queries.Category.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<GetCategoryByIdViewModel>
{
    public string Id { get; set; }
}