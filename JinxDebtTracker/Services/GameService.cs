
using jinx_debt_tracker.Interfaces;
using jinx_debt_tracker.Models;
using Refit;

namespace jinx_debt_tracker.Services;

public class GameService
{
    private readonly IGameApi _gameApi;

    public GameService(IGameApi gameApi)
    {
        _gameApi = gameApi;
    }

    public async Task<List<Game>> GetAllGames()
    {
        var values = await _gameApi.GetAllGames();
        return values;
    }

    public async Task<Game> UpdateGame(Game game)
    {
        var newGame = await _gameApi.UpdateGameByID(game);
        return newGame;
    }
}