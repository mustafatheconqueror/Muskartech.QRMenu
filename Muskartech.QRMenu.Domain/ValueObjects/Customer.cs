using Muskartech.QRMenu.Domain.Common;

namespace Muskartech.QRMenu.Domain.ValueObjects;

public class Customer : IValueObject
{
    public Customer(string name, string phone, string email)
    {
        Name = name;
        Phone = phone;
        Email = email;
    }

    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}