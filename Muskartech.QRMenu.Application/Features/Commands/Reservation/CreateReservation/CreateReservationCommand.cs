using MediatR;
using Muskartech.QRMenu.Application.Wrappers;

namespace Muskartech.QRMenu.Application.Features.Commands.Reservation.CreateReservation;

public class CreateReservationCommand : IRequest<CommandResult>
{
    public string RestaurantId { get; set; }
    public string TableId { get; set; } 
    public CustomerDto Customer { get; set; } 
    public DateTime ReservationStartTime { get; set; }
    public DateTime ReservationEndTime { get; set; }
}

// Müşteri bilgileri DTO'su
public class CustomerDto
{
    public string Name { get; set; } 
    public string Phone { get; set; } 
    public string Email { get; set; } 
}
