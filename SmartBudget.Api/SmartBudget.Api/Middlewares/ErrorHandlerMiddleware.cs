using Microsoft.AspNetCore.Mvc;
using SmartBudget.Api.Exceptions;

namespace SmartBudget.Api.Middlewares;

public sealed class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(ex, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var details = GetErrorDetails(exception);

        context.Response.StatusCode = details.Status!.Value;

        await context.Response
            .WriteAsJsonAsync(details);
    }

    private static ProblemDetails GetErrorDetails(Exception exception)
        => exception switch
        {
            EntityNotFoundException => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Не найдено",
                Detail = exception.Message
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Внутренняя ошибка сервера",
                Detail = exception.Message
            }
        };
}
