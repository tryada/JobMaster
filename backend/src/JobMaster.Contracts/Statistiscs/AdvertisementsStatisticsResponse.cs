namespace JobMaster.Contracts.Advertisements;

public record AdvertisementsStatisticsResponse(
    int Count,
    int AppliedCount,
    int RepliedCount,
    int RejectedCount
);