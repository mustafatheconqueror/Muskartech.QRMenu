namespace Muskartech.QRMenu.Application.Features.Queries.Reservation;

public class GetReservationByIdViewModel
{
    public string RestaurantId { get; set; }
    public CustomerViewModel CustomerInfo { get; set; }
    public DateTime ReservationStartTime { get; set; }
    public DateTime ReservationEndTime { get; set; }
    public int TableId { get; set; }
    public int Status { get; set; }
}

public class CustomerViewModel
{
    public string Name { get; set; }

    public string Phone { get; set; }
    public string Email { get; set; }
}