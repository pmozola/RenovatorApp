namespace RenovatorApp.Domain;

public class Room : Entity
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public int Elevation { get; init; } = 0;

    public static Room Create(string requestName, string requestDescription, int? requestElevation)
    {
        if (string.IsNullOrWhiteSpace(requestName))
            throw new ArgumentException(
                $"'{nameof(requestName)}' cannot be null or whitespace.",
                nameof(requestName));

        if (string.IsNullOrWhiteSpace(requestDescription))
            throw new ArgumentException(
                $"'{nameof(requestDescription)}' cannot be null or whitespace.",
                nameof(requestDescription));
        
        return new Room
        {
            Name = requestName,
            Description = requestDescription,
            Elevation = requestElevation ?? 0
        };
    }
}