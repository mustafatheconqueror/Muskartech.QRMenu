using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Domain.Common;

namespace Muskartech.QRMenu.Domain.ValueObjects;

[BsonIgnoreExtraElements]
public class Money : IValueObject
{
    public Money(string currencyCode, decimal value)
    {
        CurrencyCode = currencyCode;
        Value = value;
    }

    public string CurrencyCode { get; protected set; }
    public decimal Value { get; protected set; }
}