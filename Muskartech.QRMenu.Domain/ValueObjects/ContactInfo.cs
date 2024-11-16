using Muskartech.QRMenu.Domain.Common;

namespace Muskartech.QRMenu.Domain.ValueObjects;

public class ContactInfo : IValueObject
{
    public ContactInfo(string name, string surname, string email, string phone, string position)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Phone = phone;
        Position = position;
    }

    public string Name { get; protected set; }
    public string Surname { get; protected set; }
    public string Email { get; protected set; }
    public string Phone { get; protected set; }
    public string Position { get; protected set; }
}