using GameStoreApp.Data;
using GameStoreApp.Dtos;
using GameStoreApp.Entities;
using GameStoreApp.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameStoreApp.Controllers
{
    [Route("GameStore")]
    //[Route("api/[controller]")]
    [ApiController]
    public class GameStoreController : ControllerBase
    {
        private const string _GetEndpointName = "GetGameById";
        [HttpGet("Games")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GameSummaryDto>>> GetGames(GameStoreContext DbContext)
        {
            return Ok(await DbContext.Games
                .Include(g=>g.Gener)
                .Select(g => g.ToGameSummaryDto())
                .AsNoTracking().ToListAsync());
        }

        //The Name prop for RoutName
        [HttpGet("Game/{id}", Name = _GetEndpointName)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GameSummaryDto>> GetGame(int id, GameStoreContext DbContext)
        {
            Game? Game = await DbContext.Games.FindAsync(id);
          

            return Game is not null?  Ok(Game.ToGameDetailsDto()): NotFound("Invalid GameID");
        }

        [HttpPost("Game")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> PostGame(CreateGameDto NewGame, GameStoreContext DbContext)
        {
            Game NGame = NewGame.ToEntity();
            NGame.Gener = await DbContext.Geners.FindAsync(NewGame.GenerId)!;
            DbContext.Games.Add(NGame);
            await DbContext.SaveChangesAsync();
            return CreatedAtRoute(_GetEndpointName, new { id = NGame.Id }, NGame.ToGameSummaryDto());
        }

        [HttpDelete("Game/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteGame(int id, GameStoreContext DbContext)
        {
            var Game = await DbContext.Games.FindAsync(id);
            if(Game is not null)
            {
                DbContext.Remove(Game);
                DbContext.SaveChanges();
            }
          
            return NoContent();
        }

        [HttpPut("Game/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateGame(int id,UpdateGameDto UpdatedGame, GameStoreContext DbContext)
        {
            Game? game =await DbContext.Games.FindAsync(id);
            if (game == null) return NotFound();

            DbContext.Entry(game).CurrentValues.SetValues(UpdatedGame.ToEntity(id));
            await DbContext.SaveChangesAsync();
          
            return NoContent();
        }
    }
}
