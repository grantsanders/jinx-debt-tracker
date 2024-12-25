using jinx_debt_tracker.Interfaces;
using jinx_debt_tracker.Models;

namespace jinx_debt_tracker.Services;

public class PlayerService
{
    private readonly IPlayerApi _playerApi;
    public Dictionary<int, Player> PlayerList { get; set; } = new();
    
    public PlayerService(IPlayerApi playerApi)
    {
        _playerApi = playerApi;
    }

    public async Task GetAllPlayers()
    {
        var players = await _playerApi.GetAllPlayersAsync();
        PlayerList = players.ToDictionary(player => player.ID);
    }

}