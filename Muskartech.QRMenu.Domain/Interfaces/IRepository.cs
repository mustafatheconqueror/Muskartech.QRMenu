using Muskartech.QRMenu.Domain.Entities;

namespace Muskartech.QRMenu.Domain.Interfaces;

public interface IRepository<in T> where T : Entity
{
    Task InsertAsync(T entity);
}

