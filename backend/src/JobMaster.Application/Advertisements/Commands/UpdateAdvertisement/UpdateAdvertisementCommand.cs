using JobMaster.Domain.Advertisements;
using MediatR;

namespace JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;

public record UpdateAdvertisementCommand(
    Guid Id,
    string Title,
    string CompanyName,
    string Description,
    List<Guid> Skills,
    string Url,
    bool Applied,
    DateTime AppliedDate,
    bool Rejected) : IRequest<Advertisement>;