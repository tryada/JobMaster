using System.Net;

namespace JobMaster.Domain.Common.Exceptions;

public class ValidationException(Dictionary<string, string> detailsDictionary) 
    : JobMasterException("The request is not valid", HttpStatusCode.BadRequest, detailsDictionary)
{
    public override Dictionary<string, object?> GetExtensions()
    {
        var details = new List<Dictionary<string, string>>();
        foreach (var (key, value) in DetailsDictionary)
        {
            details.Add(
                new Dictionary<string, string>
                {
                    {"property", key.ToLower()},
                    {"detail", value}
                }
            );
        }

        return new Dictionary<string, object?>
        {
            {
                "errors",
                details
            }
        };
    }
}