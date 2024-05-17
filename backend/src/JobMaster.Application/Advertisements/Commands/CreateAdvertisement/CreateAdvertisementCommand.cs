using JobMaster.Domain.Advertisements;
using MediatR;

namespace JobMaster.Application.Advertisements.Commands.CreateAdvertisement;

public record CreateAdvertisementCommand(
    string Title, 
    string Description, 
    string CompanyName,
    Guid[] Skills,
    string Url,
    bool Applied,
    DateTime AppliedDate,
    bool Rejected) : IRequest<Advertisement>;