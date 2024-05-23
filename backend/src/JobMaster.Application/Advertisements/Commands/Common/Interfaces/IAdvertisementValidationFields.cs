namespace JobMaster.Application.Advertisements.Commands.Common.Interfaces;

public interface IAdvertisementValidationFields
{
    string Title { get; }
    string CompanyName { get; }
    string Description { get; }
    string Url { get; }
}