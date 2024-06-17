namespace GameService.Dtos.Games;

public sealed record GameCreateDto(
    string Name,
    string Author,
    string VideoUrl,
    decimal Price,
    string Description,
    string MinimumSystemRequirement,
    string RecommendedSystemRequirement,
    Guid CategoryId
    );