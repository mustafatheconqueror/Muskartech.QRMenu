namespace Muskartech.QRMenu.Infrastructure.Exceptions;

public class IdempotencyException : RepositoryException
{
    public IdempotencyException(string message, Exception innerException)
        : base(message, innerException)
    { }
}