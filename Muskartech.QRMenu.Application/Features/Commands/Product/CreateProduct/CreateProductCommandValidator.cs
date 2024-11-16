using FluentValidation;

namespace Muskartech.QRMenu.Application.Features.Commands.Product.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(64).WithMessage("Product name cannot exceed 100 characters.");

        RuleFor(command => command.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(command => command.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(command => command.ImageUrl)
            .MaximumLength(200).WithMessage("Image URL cannot exceed 200 characters.")
            .Matches(@"^https?:\/\/.*").WithMessage("Image URL must be a valid URL.")
            .When(command => !string.IsNullOrEmpty(command.ImageUrl)); // Only validate if not null or empty

        RuleFor(command => command.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required.");

        RuleFor(command => command.PlaceId)
            .NotEmpty().WithMessage("PlaceId is required.");
    }
}