using TeamAPI.Models;
using TeamAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamAPI.Repository
{
    public interface ITeamRepository
    {
        Task<List<TeamViewModel>> GetAllTeams();
        Task<TeamViewModel> GetTeam(int? TeamId);
        Task<int> AddTeam(Teams team);
        Task<List<TeamViewModel>> GetAllTeamsOrderedByName();
        Task<List<TeamViewModel>> GetAllTeamsOrderedByLocation();
    }
}
