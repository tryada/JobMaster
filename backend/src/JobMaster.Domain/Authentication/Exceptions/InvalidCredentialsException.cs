using System.Net;
using JobMaster.Domain.Common.Exceptions;

namespace JobMaster.Domain.Authentication.Exceptions;

public class InvalidCredentialsException() 
    : JobMasterException("Invalid credentials", HttpStatusCode.BadRequest)
{
}