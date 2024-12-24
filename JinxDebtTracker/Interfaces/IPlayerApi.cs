using jinx_debt_tracker.Models;
using Refit;

namespace jinx_debt_tracker.Interfaces;

public interface IPlayerApi
{
    [Get("/GetPlayer/{id}")]
    Task<Player> GetPlayerAsync(int id);
    [Get("/GetAllPlayers")]
    Task<List<Player>> GetAllPlayersAsync();

}