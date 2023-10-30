using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using System.Threading.Tasks;
using System;


namespace TestWebApi.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        GameContext db;
        public GamesController(GameContext context)
        {
            db = context;
            if (!db.Games.Any())
            {
                db.Games.Add(new Game { NameGame = "Doom", StudioDeveloper = "id Software", GameGenre= "Шутер" });
                db.Games.Add(new Game { NameGame = "Metro 2033", StudioDeveloper = "4A Games", GameGenre = "Шутер" });
                db.Games.Add(new Game { NameGame = "Warcraft III: Reign of Chaos", StudioDeveloper = "Blizzard Entertainment", GameGenre = "Стратегия" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesAll()
        {
            return await db.Games.ToListAsync();
        }

        [HttpGet("{GameGenre}")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesByGenre(string gameGenre)
        {
            return await db.Games.Where(x => x.GameGenre == gameGenre).ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
            if (game == null)
            {
                return BadRequest();
            }

            db.Games.Add(game);
            await db.SaveChangesAsync();
            return Ok(game);
        }

        [HttpPut]
        public async Task<ActionResult<Game>> UpdateGame(Game game)
        {
            if (game == null)
            {
                return BadRequest();
            }
            if (!db.Games.Any(x => x.Id == game.Id))
            {
                return NotFound();
            }

            db.Update(game);
            await db.SaveChangesAsync();
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            Game game = db.Games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            db.Games.Remove(game);
            await db.SaveChangesAsync();
            return Ok(game);
        }
    }
}
