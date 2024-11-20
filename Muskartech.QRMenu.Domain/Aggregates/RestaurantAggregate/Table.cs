using Muskartech.QRMenu.Domain.Entities;

namespace Muskartech.QRMenu.Domain.Aggregates.RestaurantAggregate;

public class Table : Entity
{
    public Table(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
    }


    public string Name { get; set; }

    public int Capacity { get; protected set; }
}