using MediatR;

namespace Muskartech.QRMenu.Application.Features.Queries.Reservation;

public class GetReservationByIdQuery : IRequest<GetReservationByIdViewModel>
{
    public string Id { get; set; }
}