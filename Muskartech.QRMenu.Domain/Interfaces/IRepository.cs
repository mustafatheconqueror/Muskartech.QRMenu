using Muskartech.QRMenu.Domain.Entities;

namespace Muskartech.QRMenu.Domain.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task InsertAsync(T entity, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);
}

