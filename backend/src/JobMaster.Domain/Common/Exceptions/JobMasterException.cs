using System.Net;

namespace JobMaster.Domain.Common.Exceptions;

public abstract class JobMasterException(string message, HttpStatusCode code) : Exception(message)
{
    public HttpStatusCode Code { get; private set; } = code;
    protected Dictionary<string, string> DetailsDictionary { get; private set; } = [];

    protected JobMasterException(string message, HttpStatusCode code, Dictionary<string, string> detailsDictionary)
        : this(message, code)
    {
        DetailsDictionary = detailsDictionary;
    }

    public virtual Dictionary<string, object?> GetExtensions() 
    {
        return null;
    }
}