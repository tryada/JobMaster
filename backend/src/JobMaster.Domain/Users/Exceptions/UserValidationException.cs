
using JobMaster.Domain.Common.Exceptions;

namespace JobMaster.Domain.Users.Exceptions;

public class UserValidationException(Dictionary<string, string> detailsDictionary) 
    : ValidationException(detailsDictionary)
{
}