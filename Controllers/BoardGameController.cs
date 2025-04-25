using COMP003B.Assignment5.Data;
using COMP003B.Assignment5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardGameController : Controller
    {
        [HttpGet]
        public ActionResult<List<BoardGame>> GetBoardGames()
        {
            return Ok(BoardGameStore.BoardGames);
        }

        [HttpGet("{id}")]
        public ActionResult<BoardGame> GetBoardGame(int id)
        {
            var boardgame = BoardGameStore.BoardGames.FirstOrDefault(p => p.Id == id);
            
            if (boardgame is null)
                return NotFound();

            return Ok(boardgame);
        }

        [HttpPost]
        public ActionResult<BoardGame> CreateBoardGame(BoardGame boardgame)
        {
            boardgame.Id = BoardGameStore.BoardGames.Max(p => p.Id) + 1;

            BoardGameStore.BoardGames.Add(boardgame);

            return CreatedAtAction(nameof(GetBoardGame), new { id = boardgame.Id }, boardgame);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBoardGame(int id, BoardGame updatedBoardGame)
        {
            var existingBoardGame = BoardGameStore.BoardGames.FirstOrDefault(p => p.Id == id);

            if (existingBoardGame is null)
                return NotFound();

            existingBoardGame.Name = updatedBoardGame.Name;
            existingBoardGame.MaxPlayers = updatedBoardGame.MaxPlayers;
            existingBoardGame.MinPlayers = updatedBoardGame.MinPlayers;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBoardGame(int id)
        {
            var boardgame = BoardGameStore.BoardGames.FirstOrDefault(p => p.Id == id);

            if (boardgame is null)
                return NotFound();

            BoardGameStore.BoardGames.Remove(boardgame);

            return NoContent();
        }
    }
}
