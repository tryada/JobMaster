using JobMaster.Domain.Common.Exceptions;

namespace JobMaster.Domain.Skills.Exceptions;

public class SkillValidationException(Dictionary<string, string> detailsDictionary) 
    : ValidationException(detailsDictionary)
{
}