using GameStoreApp.Dtos;
using GameStoreApp.Entities;

namespace GameStoreApp.Mapping
{
    public static class clsHelperMapping
    {
        public static GameSummaryDto ToGameSummaryDto(this Game game)
        {

            return new(
                game.Id,
                game.Name!,
                game.Gener!.Name,
                game.Price,
                game.ReleasDate);
        }
        public static GameDetailsDto ToGameDetailsDto(this Game game)
        {
            return new(game.Id, game.Name!, game.GenerID, game.Price, game.ReleasDate);
        }
        public static Game ToEntity(this CreateGameDto NewGame)
        {
            return new Game { Name = NewGame.Name, GenerID = NewGame.GenerId, Price = NewGame.Price, ReleasDate = NewGame.ReleasDate };
        }
        public static Game ToEntity(this UpdateGameDto updateGame, int id)
        {
            return new Game { Id = id, Name = updateGame.Name, GenerID = updateGame.GenerId, Price = updateGame.Price, ReleasDate = updateGame.ReleasDate };
        }
    }
}
