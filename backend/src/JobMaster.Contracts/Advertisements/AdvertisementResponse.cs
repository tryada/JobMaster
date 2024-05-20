namespace JobMaster.Contracts.Advertisements;

public record AdvertisementResponse(
    string Id,
    string Title,
    string CompanyName,
    string Description,
    string[] Skills,
    string Url,
    bool Applied,
    DateTime? AppliedDate,
    bool Rejected
);