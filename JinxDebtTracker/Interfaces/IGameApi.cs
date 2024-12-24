using jinx_debt_tracker.Models;
using Refit;

namespace jinx_debt_tracker.Interfaces;

public interface IGameApi
{
    [Get("/GetAllGames")]
    Task<List<Game>> GetAllGames();
    [Get("/GetGame/{player1Id}/{player2Id}")]
    Task<Game> GetGameByPlayerIds(int player1Id, int player2Id);
    Task<Game> UpdateGameByID();
    Task<Game> CreateGame();
}