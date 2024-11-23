using AutoMapper;
using MediatR;
using Muskartech.QRMenu.Domain.Interfaces;

namespace Muskartech.QRMenu.Application.Features.Queries.Reservation;

public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdViewModel>
{
    private readonly IReservationRepository _reservationRepository;

    private readonly IMapper _mapper;

    public GetReservationByIdQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    public async Task<GetReservationByIdViewModel> Handle(GetReservationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<GetReservationByIdViewModel>(reservation);
    }
}