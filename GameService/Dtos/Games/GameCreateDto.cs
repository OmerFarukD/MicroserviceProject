﻿namespace GameService.Dtos.Games;

public sealed record GameCreateDto(
    string Name,
    string Author,
    IFormFile File,
    decimal Price,
    string Description,
    string MinimumSystemRequirement,
    string RecommendedSystemRequirement,
    Guid CategoryId
    );