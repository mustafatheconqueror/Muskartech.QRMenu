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
        //Todo: bu kontrollei bir validatöre aktar.
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            //todo: BadRequest dön :)
            throw new ArgumentException("Category name cannot be null or empty.", nameof(request.Name));
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            throw new ArgumentException("Category description cannot be null or empty.", nameof(request.Description));
        }

        var category =
            Domain.Aggregates.CategoryAggregate.Category.Create(request.Name!, request.Description!,
                request.CustomerId!);

        //Todo burada var = result deyip başarılı insert edilemediğinin hatası yakalanabilir. Şart değil.
        await _categoryRepository.InsertAsync(category, cancellationToken);


        return new CommandResult(HttpStatusCode.Created, new { CategoryId = category.Id });
    }
}