namespace GameStoreApi.DTOs;

public record class GameSummaryDto
(
    int Id,
    string Name,
    string Gener,
    double Price,
    DateOnly ReleasDate
);
