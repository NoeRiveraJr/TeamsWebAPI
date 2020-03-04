using System;
using TeamAPI.Models;
using TeamAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamAPI.Repository
{
    public class TeamRepository : ITeamRepository
    {
        TeamsContext db;
        public TeamRepository(TeamsContext _db)
        {
            db = _db;
        }

        public async Task<int> AddTeam(Teams team)
        {
            if (db != null)
            {
                await db.Teams.AddAsync(team);
                await db.SaveChangesAsync();
                return team.Id;
            }
            return 0;
        }

        public async Task<TeamViewModel> GetTeam(int? TeamId)
        {
            if (db != null)
            {
                return await (from t in db.Teams
                              where t.Id == TeamId
                              select new TeamViewModel
                              {
                                  TeamID = t.Id,
                                  TeamLocation = t.Location,
                                  TeamName = t.Name
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<TeamViewModel>> GetAllTeams()
        {
            if (db != null)
            {
                return await (from t in db.Teams
                              select new TeamViewModel
                              {
                                  TeamID = t.Id,
                                  TeamLocation = t.Location,
                                  TeamName = t.Name
                              }).ToListAsync();
            }
            return null;
        }

        public async Task<List<TeamViewModel>> GetAllTeamsOrderedByName()
        {
            if (db != null)
            {
                return await (from t in db.Teams
                              orderby t.Name
                              select new TeamViewModel
                              {
                                  TeamID = t.Id,
                                  TeamLocation = t.Location,
                                  TeamName = t.Name
                              }).ToListAsync();
            }
            return null;
        }

        public async Task<List<TeamViewModel>> GetAllTeamsOrderedByLocation()
        {
            if (db != null)
            {
                return await (from t in db.Teams
                              orderby t.Location
                              select new TeamViewModel
                              {
                                  TeamID = t.Id,
                                  TeamLocation = t.Location,
                                  TeamName = t.Name
                              }).ToListAsync();
            }
            return null;
        }


    }
}
