using System.Net;
using MediatR;
using MongoDB.Bson;
using Muskartech.QRMenu.Application.Wrappers;
using Muskartech.QRMenu.Domain.Interfaces;

namespace Muskartech.QRMenu.Application.Features.Commands.Category.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CommandResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null.");
        }

        var category = new Domain.Aggregates.CategoryAggregate.Category(
            name: request.Name!,
            description: request.Description!,
            placeId: request.PlaceId!,
            imageUrl: request.ImageUrl
        );

        await _categoryRepository.InsertAsync(category, cancellationToken);

        return new CommandResult(HttpStatusCode.Created, new { CategoryId = category.Id });
    }
}