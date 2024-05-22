using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;
using MediatR;

namespace JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;

public record UpdateAdvertisementCommand(
    AdvertisementId Id,
    string Title,
    string CompanyName,
    string Description,
    List<SkillId> Skills,
    string Url,
    bool Applied,
    DateTime AppliedDate,
    bool Rejected) : IRequest<Advertisement>;