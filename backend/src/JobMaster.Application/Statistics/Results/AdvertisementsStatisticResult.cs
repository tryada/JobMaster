namespace JobMaster.Application.Advertisements.Queries.GetAdvertisementsStatistics.Result;

public record AdvertisementsStatisticResult(
    int Count,
    int AppliedCount,
    int RepliedCount,
    int RejectedCount
);