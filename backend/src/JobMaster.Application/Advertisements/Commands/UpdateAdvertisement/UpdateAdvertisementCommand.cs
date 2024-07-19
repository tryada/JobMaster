using JobMaster.Application.Advertisements.Commands.Common.Interfaces;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;
using MediatR;

namespace JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;

public record UpdateAdvertisementCommand(
    UserId UserId,
    AdvertisementId Id,
    string Title,
    string CompanyName,
    string Description,
    List<SkillId> Skills,
    string Url,
    bool Applied,
    DateTime? AppliedDate,
    bool Rejected,
    bool Replied,
    DateTime? RepliedDate) 
    : IRequest<Advertisement>, IAdvertisementValidationFields;