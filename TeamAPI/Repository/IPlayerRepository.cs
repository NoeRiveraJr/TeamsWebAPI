using TeamAPI.Models;
using TeamAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamAPI.Repository
{
    public interface IPlayerRepository
    {
        Task<List<PlayerViewModel>> GetAllPlayers();
        Task<List<PlayerViewModel>> GetTeamAndPlayers(int? TeamId);
        Task<PlayerViewModel> GetPlayer(int? PlayerId);
        Task<List<PlayerViewModel>> GetPlayersByLastName(string? LastName);
        Task<int> AddPlayer(Players player);
        Task UpdatePlayer(Players player);
    }
}
