using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Users;
using MediatR;

namespace JobMaster.Application.Advertisements.Queries.ListAdvertisements;

public record ListAdvertisementsQuery(
    UserId UserId) 
    : IRequest<List<Advertisement>>;