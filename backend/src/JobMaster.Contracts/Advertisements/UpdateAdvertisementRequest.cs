namespace JobMaster.Contracts.Advertisements;

public record UpdateAdvertisementRequest(
    string Title,
    string CompanyName,
    string Description,
    string[] Skills,
    string Url,
    bool Applied,
    DateTime? AppliedDate,
    bool Rejected,
    bool Replied,
    DateTime? ReplyDate
);