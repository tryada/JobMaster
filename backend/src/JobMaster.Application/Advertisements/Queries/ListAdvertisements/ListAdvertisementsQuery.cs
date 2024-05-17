using JobMaster.Domain.Advertisements;
using MediatR;

namespace JobMaster.Application.Advertisements.Queries.ListAdvertisements;

public record ListAdvertisementsQuery : IRequest<List<Advertisement>>;