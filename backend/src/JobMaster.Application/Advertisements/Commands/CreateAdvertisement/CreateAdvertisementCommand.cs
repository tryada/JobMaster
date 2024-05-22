using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Skills.ValueObjects;
using MediatR;

namespace JobMaster.Application.Advertisements.Commands.CreateAdvertisement;

public record CreateAdvertisementCommand(
    string Title,
    string CompanyName,
    string Description,
    List<SkillId> Skills,
    string Url,
    bool Applied,
    DateTime? AppliedDate,
    bool Rejected) : IRequest<Advertisement>;