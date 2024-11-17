namespace Muskartech.QRMenu.Infrastructure.Exceptions;



public class EntityNotFoundException : RepositoryException
{
    public EntityNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    { }
}