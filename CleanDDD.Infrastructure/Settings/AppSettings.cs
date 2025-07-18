namespace CleanDDD.Infrastructure.Settings;

public record AppSettings
{
    public required Authentication Authentication { get; init; }

    public required Cors Cors { get; init; }

    public required Cache Cache { get; init; }

    public required ConnectionStrings ConnectionStrings { get; init; }
}
