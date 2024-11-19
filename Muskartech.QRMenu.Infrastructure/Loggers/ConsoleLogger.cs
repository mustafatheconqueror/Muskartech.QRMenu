using System.Diagnostics;
using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Muskartech.QRMenu.Infrastructure.Settings;
using Newtonsoft.Json;

namespace Muskartech.QRMenu.Infrastructure.Loggers;

public class ConsoleLogger : IConsoleLogger
{
    private readonly IOptions<ConsoleLoggerSetting> _consoleLoggerSettingOptions;

    public ConsoleLogger(IOptions<ConsoleLoggerSetting> consoleLoggerSettingOptions)
    {
        _consoleLoggerSettingOptions = consoleLoggerSettingOptions;
    }

    public void Log(LogLevel logLevel, string message, Exception exception, string responseBody, string requestBody,
        HttpMethod httpMethod, HttpStatusCode httpStatusCode, long? duration, string hostName, string url,
        string userName, string origin)
    {
        if (_consoleLoggerSettingOptions.Value.MinimumLogLevel > logLevel)
        {
            return;
        }

        Console.WriteLine(JsonConvert.SerializeObject(new
        {
            CorrelationId = Trace.CorrelationManager.ActivityId,
            DateTime = DateTime.Now,
            LogLevel = logLevel.ToString(),
            Message = message,
            Exception = exception?.ToString(),
            ResponseBody = responseBody,
            RequestBody = requestBody,
            HttpMethod = httpMethod?.Method,
            HttpStatusCode = (int)httpStatusCode,
            Duration = duration,
            HostName = hostName,
            Url = url,
            UserName = userName,
            Origin = origin
        }));
    }

    public void LogTrace(string message, Exception exception = null, string responseBody = null,
        string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string hostName = null, string url = null, string userName = null, string origin = null)
    {
        Log(LogLevel.Trace, message, exception, responseBody, requestBody, httpMethod,
            httpStatusCode.GetValueOrDefault(), duration, hostName, url, userName, origin);
    }

    public void LogDebug(string message, Exception exception = null, string responseBody = null,
        string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string hostName = null, string url = null, string userName = null, string origin = null)
    {
        Log(LogLevel.Debug, message, exception, responseBody, requestBody, httpMethod,
            httpStatusCode.GetValueOrDefault(), duration, hostName, url, userName, origin);
    }

    public void LogInformation(string message, Exception exception = null, string responseBody = null,
        string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string hostName = null, string url = null, string userName = null, string origin = null)
    {
        Log(LogLevel.Information, message, exception, responseBody, requestBody, httpMethod,
            httpStatusCode.GetValueOrDefault(), duration, hostName, url, userName, origin);
    }

    public void LogWarning(string message, Exception exception = null, string responseBody = null,
        string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string hostName = null, string url = null, string userName = null, string origin = null)
    {
        Log(LogLevel.Warning, message, exception, responseBody, requestBody, httpMethod,
            httpStatusCode.GetValueOrDefault(), duration, hostName, url, userName, origin);
    }

    public void LogError(string message, Exception exception = null, string responseBody = null,
        string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string hostName = null, string url = null, string userName = null, string origin = null)
    {
        Log(LogLevel.Error, message, exception, responseBody, requestBody, httpMethod,
            httpStatusCode.GetValueOrDefault(), duration, hostName, url, userName, origin);
    }

    public void LogCritical(string message, Exception exception = null, string responseBody = null,
        string requestBody = null, HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null,
        long? duration = null, string hostName = null, string url = null, string userName = null, string origin = null)
    {
        Log(LogLevel.Critical, message, exception, responseBody, requestBody, httpMethod,
            httpStatusCode.GetValueOrDefault(), duration, hostName, url, userName, origin);
    }
}