using Muskartech.QRMenu.Domain.Common;

namespace Muskartech.QRMenu.Domain.ValueObjects;

public class ContactInfo : IValueObject
{
    public string Email { get; private set; }
    public string Phone { get; private set; }

    private ContactInfo(string email, string phone)
    {
        Email = email;
        Phone = phone;
    }

    public static ContactInfo Create(string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Either Email or Phone must be provided.");

        return new ContactInfo(email, phone);
    }
}