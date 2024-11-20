using MediatR;
using Muskartech.QRMenu.Application.Wrappers;
using Muskartech.QRMenu.Domain.ValueObjects;

namespace Muskartech.QRMenu.Application.Features.Commands.Restaurant.CreateRestaurant;

public class CreateRestaurantCommand : IRequest<CommandResult>
{
    public string Name { get; set; }
    public string? Location { get; set; }
    public List<Table> Tables { get; set; }
    public Contact? Contact { get; set; }
}

public class Table
{
    public string Name { get; set; }
    public int Capacity { get; set; }
}

public class Contact
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}