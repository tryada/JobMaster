using System.Net;

namespace JobMaster.Domain.Common.Exceptions;

public abstract class JobMasterException(string message, HttpStatusCode code) : Exception(message)
{
    public HttpStatusCode Code { get; private set; } = code;
}