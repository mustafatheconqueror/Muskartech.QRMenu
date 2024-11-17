using FluentValidation;

namespace Muskartech.QRMenu.Application.Features.Commands.Place.CreatePlace;

public class CreatePlaceCommandValidator : AbstractValidator<CreatePlaceCommand>
{
    public CreatePlaceCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(command => command.Location)
            .NotEmpty().WithMessage("Location cannot be empty.");

        RuleFor(command => command.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(command => command.OwnerContactInfo)
            .NotNull().WithMessage("OwnerContactInfo cannot be null.")
            .Must(contactInfo => !string.IsNullOrWhiteSpace(contactInfo.Email) ||
                                 !string.IsNullOrWhiteSpace(contactInfo.Phone))
            .WithMessage("At least one of Email or Phone must be provided in OwnerContactInfo.");

        RuleFor(command => command.PlaceType)
            .IsInEnum().WithMessage("Invalid PlaceType value.");
    }
}