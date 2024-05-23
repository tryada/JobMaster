using JobMaster.Domain.Common.Exceptions;

namespace JobMaster.Domain.Advertisements.Exceptions;

public class AdvertisementValidationException(Dictionary<string, string> detailsDictionary)
    : ValidationException(detailsDictionary)
{
}