namespace Muskartech.QRMenu.Application.Features.Queries.Restaurant;

public class GetRestaurantByIdViewModel
{
    public string Name { get; set; }

    public string Location { get; set; }

    public List<TableViewModel>? Table { get; set; }
    public ContactInfoViewModel OwnerContactInfo { get; set; }
}

public class TableViewModel
{
    public string Name { get; set; }
    public int Capacity { get; set; }
}

public class ContactInfoViewModel
{
    public string Name { get; set; }
    public int Capacity { get; set; }
}