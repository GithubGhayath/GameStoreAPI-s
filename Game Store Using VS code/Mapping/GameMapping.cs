using System;
using GameStoreApi.DTOs;
using GameStoreApi.Entities;

namespace GameStoreApi.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game()
        {
            Name = game.Name,
            GenerID = game.GenerID,
            Price = game.Price,
            ReleasDate = game.ReleasDate
        };
    }
    public static Game ToEntity(this UpdateDto game, int id)
    {
        return new Game()
        {
            GameID = id,
            Name = game.Name,
            GenerID = game.GenerID,
            Price = game.Price,
            ReleasDate = game.ReleasDate
        };
    }

    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return new(game.GameID, game.Name, game.Gener!.Name, game.Price, game.ReleasDate);
    }

    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new(game.GameID, game.Name, game.GenerID, game.Price, game.ReleasDate);
    }
}
