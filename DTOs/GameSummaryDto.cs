namespace GameStoreApi.DTOs;

public record class GameDto
(
    int Id,
    string Name,
    string Gener,
    double Price,
    DateOnly ReleasDate
);
