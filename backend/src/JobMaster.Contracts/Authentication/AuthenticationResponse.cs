namespace JobMaster.Contracts.Authentication;

public record AuthenticationResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string Token,
    DateTime ExpirationDate
);