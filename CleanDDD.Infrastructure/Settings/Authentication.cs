namespace CleanDDD.Infrastructure.Settings;

public record Authentication(string Authority, string Audience, string ClientId, string SecretKey, string Issuer, int Expired);
