using FluentValidation;

namespace Muskartech.QRMenu.Application.Features.Commands.Place.CreatePlace;

public class CreatePlaceCommandValidator : AbstractValidator<CreatePlaceCommand>
{
    public CreatePlaceCommandValidator()
    {
        RuleFor(command => command.Location)
            .NotEmpty().WithMessage("Location cannot be empty.")
            .NotNull().WithMessage("Location cannot be null.");
        
        RuleFor(command => command.OwnerName)
            .NotEmpty().WithMessage("OwnerName cannot be empty.")
            .NotNull().WithMessage("LocaOwnerNametion cannot be null.");
    }
}
