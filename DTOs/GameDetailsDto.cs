namespace GameStoreApi.DTOs;

public record class GameDetailsDto
(
    int Id,
    string Name,
    int GenerId,
    double Price,
    DateOnly ReleasDate
);