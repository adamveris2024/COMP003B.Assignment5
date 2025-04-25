using COMP003B.Assignment5.Models;

namespace COMP003B.Assignment5.Data
{
    public class BoardGameStore
    {
        public static List<BoardGame> BoardGames { get; } = new()
        {
            new BoardGame { Id = 1, Name = "Monopoly", MinPlayers = 2, MaxPlayers = 8},
            new BoardGame { Id = 2, Name = "Uno", MinPlayers = 2, MaxPlayers = 4},
            new BoardGame { Id = 3, Name = "Jenga", MinPlayers = 2, MaxPlayers = 8}
        };
    }
}
