using System;
using GameStoreApi.Data;
using GameStoreApi.DTOs;
using GameStoreApi.Entities;
using GameStoreApi.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.GameEndPoints;

public static class clsEndPoints
{

    private readonly static List<GameDto> Games = [
        new (1,"Street Fighter II", "Fighting", 19.99d, new DateOnly(1992, 2, 12)),
        new (2,"Final Fantasy XIV", "RolePlaying", 59.99d, new DateOnly(2000, 1, 15)),
        new (3,"FIFA 23", "Sports", 89.99d, new DateOnly(2023, 12, 12)),
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        const string FindEndPointName = "GetGame";
        //Endpoint filter method: .WithParameterValidation()
        //this is in package: minimal apis.extensions
        var GroupGame = app.MapGroup("games").WithParameterValidation();


        // GET /games
        //This method must return game as dto (each recored)
        GroupGame.MapGet("/", handler: (GameStoreContext DbContect) => DbContect.Games
        .Include(game => game.Gener)
        .Select(g => g.ToGameSummaryDto())
        .AsNoTracking());

        // GET /games/1
        GroupGame.MapGet("/{id}", (int id, GameStoreContext DbContect) =>
        {
            Game? Game = DbContect.Games.Find(id);
            return Game is null ? Results.NotFound() : Results.Ok(Game.ToGameDetailsDto());
        }).WithName(FindEndPointName);

        //POST /games
        GroupGame.MapPost("/", (CreateGameDto NewGame, GameStoreContext DbContect) =>
        {

            Game game = NewGame.ToEntity();
            game.Gener = DbContect.Geners.Find(NewGame.GenerID);

            DbContect.Games.Add(game);
            DbContect.SaveChanges();


            //at this line there is a problem
            return Results.CreatedAtRoute(FindEndPointName, new { id = game.GameID }, game.ToGameSummaryDto());
        });


        //PUT /games/1
        GroupGame.MapPut("/{GameId}", (int GameId, UpdateDto UpdatedGame, GameStoreContext DbContect) =>
        {
            //The find method will search for the game by primary key so we should pass primary key
            var CurrentGame = DbContect.Games.Find(GameId);
            //if we want to path like example name we should use FirstOrDefault(g => g.Name == "SomeGameName")

            //if game that looking for not found
            if (CurrentGame is null) return Results.NotFound();

            //else

            /*
                        1-DbContect.Entry(CurrentGame)
                        This gets the tracking information for CurrentGame in the database.


                        2-Entry(CurrentGame) returns an EntityEntry object, which allows you to modify entity states and values.
                        .CurrentValues.SetValues(...)

                        This replaces the current values of CurrentGame with the new values from another object.
                        It doesn't replace the whole entity, just its properties.
                        UpdatedGame.ToEntity(UpdatedGame.Id)

                        This method (ToEntity(UpdatedGame.Id)) converts UpdatedGame (likely a DTO) into an entity object (Game).
            */
            DbContect.Entry(CurrentGame).CurrentValues.SetValues(UpdatedGame.ToEntity(GameId));
            DbContect.SaveChanges();
            return Results.NoContent();
        });


        //DELETE /games/2
        GroupGame.MapDelete("/{GameId}", (int GameId, GameStoreContext DbContext) =>
        {
            var game = DbContext.Games.Find(GameId);
            if (game is not null)
            {
                DbContext.Remove(game);
                DbContext.SaveChanges();
            }

            return Results.NoContent();
        });

        return GroupGame;

    }
}
