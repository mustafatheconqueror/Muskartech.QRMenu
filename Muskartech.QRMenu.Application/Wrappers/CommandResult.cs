using System.Net;

namespace Muskartech.QRMenu.Application.Wrappers;

public class CommandResult
{
    public CommandResult(HttpStatusCode httpStatusCode)
    {
        this.HttpStatusCode = httpStatusCode;
    }

    public CommandResult(HttpStatusCode httpStatusCode, object result)
    {
        this.HttpStatusCode = httpStatusCode;
        this.Result = result;
    }

    public object? Result { get; private set; }
    public HttpStatusCode HttpStatusCode { get; private set; }
}