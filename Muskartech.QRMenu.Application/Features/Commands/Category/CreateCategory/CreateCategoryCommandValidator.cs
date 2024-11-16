using MongoDB.Bson;

namespace Muskartech.QRMenu.Application.Features.Commands.Category.CreateCategory;

using FluentValidation;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(command => command.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(command => command.CustomerId)
            .NotEmpty().WithMessage("CustomerId (PlaceId) cannot be empty.")
            .Must(IsValidObjectId).WithMessage("CustomerId must be a valid ObjectId.");
    }

    private bool IsValidObjectId(string? objectId)
    {
        return ObjectId.TryParse(objectId, out _);
    }
}
