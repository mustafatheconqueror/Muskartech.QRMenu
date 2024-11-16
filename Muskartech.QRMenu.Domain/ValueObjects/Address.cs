using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Domain.Common;

namespace Muskartech.QRMenu.Domain.ValueObjects;

[BsonIgnoreExtraElements]
public class Address : IValueObject
{
    public Address(string addressRefId, string addressDetail, string countryCode, string country, string city, string district, string gsmNumber, string telNumber, string addressTitle, string postalCode)
    {
        AddressRefId = addressRefId;
        AddressDetail = addressDetail;
        CountryCode = countryCode;
        Country = country;
        City = city;
        District = district;
        GsmNumber = gsmNumber;
        TelNumber = telNumber;
        AddressTitle = addressTitle;
        PostalCode = postalCode;
    }

    public string AddressRefId { get; protected set; }

    public string AddressDetail { get; protected set; }

    public string CountryCode { get; protected set; }

    public string Country { get; protected set; }

    public string City { get; protected set; }

    public string District { get; protected set; }

    public string GsmNumber { get; protected set; }
    
    public string TelNumber { get; protected set; }
    
    public string AddressTitle { get; protected set; }

    public string PostalCode { get; protected set; }
}