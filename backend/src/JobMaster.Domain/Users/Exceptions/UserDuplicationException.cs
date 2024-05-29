using System.Net;
using JobMaster.Domain.Common.Exceptions;

namespace JobMaster.Domain.Users.Exceptions;

public class UserDuplicationException(string email) 
    : JobMasterException($"User with email {email} already exists", HttpStatusCode.Conflict)
{
}