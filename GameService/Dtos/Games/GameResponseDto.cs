namespace GameService.Dtos.Games;

public sealed record GameResponseDto(
    Guid Id,
    string Name,
    string Author,
    IFormFile File,
    decimal Price,
    string Description,
    string MinimumSystemRequirement,
    string RecommendedSystemRequirement,
    string CategoryName
);