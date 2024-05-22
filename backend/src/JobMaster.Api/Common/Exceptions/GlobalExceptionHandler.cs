using System.Net;
using JobMaster.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JobMaster.Api.Common.Exceptions;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is JobMasterException jobMasterException)
            return await HandleCustomErrors(httpContext, jobMasterException, cancellationToken);

        return await HandleDefaultErrors(httpContext, exception, cancellationToken);
    }

    private static async ValueTask<bool> HandleCustomErrors(HttpContext httpContext, JobMasterException jobMasterException, CancellationToken cancellationToken)
    {
        await HandleError(httpContext, cancellationToken, jobMasterException.Code, jobMasterException.Message);
        return true;
    }

    private static async ValueTask<bool> HandleDefaultErrors(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        await HandleError(httpContext, cancellationToken, HttpStatusCode.InternalServerError, exception.Message);
        return true;
    }

    private static async Task HandleError(
        HttpContext httpContext, 
        CancellationToken cancellationToken,
        HttpStatusCode statusCode,
        string detail)
    {
        httpContext.Response.StatusCode = (int)statusCode;
        httpContext.Response.ContentType = "application/problem+json";

        var problemDetails = new ProblemDetails
        {
            Detail = detail,
            Status = (int)statusCode
        };

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
    }
}