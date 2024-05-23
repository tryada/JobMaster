using JobMaster.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JobMaster.Api.Common.Exceptions;

public sealed class JobMasterExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is JobMasterException jobMasterException)
        {
            httpContext.Response.StatusCode = (int)jobMasterException.Code;
            httpContext.Response.ContentType = "application/problem+json";

            var problemDetails = new ProblemDetails
            {
                Detail = exception.Message,
                Status = (int)jobMasterException.Code,
                Extensions = jobMasterException.GetExtensions()
            };

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }

        return await Task.FromResult(false);
    }
}
