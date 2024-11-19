using System.Net;
using Microsoft.Extensions.Logging;

namespace Muskartech.QRMenu.Infrastructure.Loggers;

public interface IConsoleLogger
{
    void Log(LogLevel logLevel, string message, Exception exception, string responseBody, string requestBody,
        HttpMethod httpMethod, HttpStatusCode httpStatusCode, long? duration, string hostName, string url,
        string userName, string origin);

    void LogTrace(string message, Exception exception = null, string responseBody = null,
        string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string hostName = null, string url = null, string userName = null, string origin = null);

    void LogDebug(string message, Exception exception = null, string responseBody = null, string requestBody = null,
        HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
        string hostName = null, string url = null, string userName = null, string origin = null);

    void LogInformation(string message, Exception exception = null, string responseBody = null,
        string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string hostName = null, string url = null, string userName = null, string origin = null);

    void LogWarning(string message, Exception exception = null, string responseBody = null,
        string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string hostName = null, string url = null, string userName = null, string origin = null);

    void LogError(string message, Exception exception = null, string responseBody = null, string requestBody = null,
        HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
        string hostName = null, string url = null, string userName = null, string origin = null);

    void LogCritical(string message, Exception exception = null, string responseBody = null,
        string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string hostName = null, string url = null, string userName = null, string origin = null);
}