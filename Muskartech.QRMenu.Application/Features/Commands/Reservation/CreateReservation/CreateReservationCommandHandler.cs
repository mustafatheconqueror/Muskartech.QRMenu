using System.Net;
using MediatR;
using Muskartech.QRMenu.Application.Wrappers;
using Muskartech.QRMenu.Domain.Interfaces;
using Muskartech.QRMenu.Domain.ValueObjects;

namespace Muskartech.QRMenu.Application.Features.Commands.Reservation.CreateReservation;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, CommandResult>
{
    private readonly IReservationRepository _reservationRepository;

    public CreateReservationCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<CommandResult> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null.");
        }

        var customer = new Customer(request.Customer.Name, request.Customer.Phone, request.Customer.Email);

        // Rezervasyon nesnesini oluşturma
        var reservation = new Domain.Aggregates.ReservationAggregate.Reservation(
            restaurantId: request.RestaurantId ?? throw new ArgumentNullException(nameof(request.RestaurantId)),
            tableId: request.TableId ?? throw new ArgumentNullException(nameof(request.TableId)),
            customer: customer,
            reservationStartTime: request.ReservationStartTime,
            reservationEndTime: request.ReservationEndTime
        );

        // Rezervasyonu veritabanına ekleme
        await _reservationRepository.InsertAsync(reservation, cancellationToken);

        // Başarılı yanıt döndürme
        return new CommandResult(HttpStatusCode.Created, new { ReservationId = reservation.Id });
    }
}