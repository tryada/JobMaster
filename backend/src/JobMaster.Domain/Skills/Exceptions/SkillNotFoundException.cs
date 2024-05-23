using System.Net;
using JobMaster.Domain.Common.Exceptions;
using JobMaster.Domain.Skills.ValueObjects;

namespace JobMaster.Domain.Skills.Exceptions;

public class SkillNotFoundException(SkillId skillId) :
    JobMasterException($"Skill with id: {skillId} was not found.", HttpStatusCode.NotFound)
{
}