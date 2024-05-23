using System.Net;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Common.Exceptions;

namespace JobMaster.Domain.Advertisements.Exceptions;

public class AdvertisementNotFoundException(AdvertisementId id) :
    JobMasterException($"Advertisement with id: {id} was not found.", HttpStatusCode.NotFound)
{

}