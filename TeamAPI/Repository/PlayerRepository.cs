using TeamAPI.Models;
using TeamAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamAPI.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        TeamsContext db;
        public PlayerRepository(TeamsContext _db)
        {
            db = _db;
        }
        public async Task<int> AddPlayer(Players player)
        {
            if (db != null)
            {
                await db.Players.AddAsync(player);
                await db.SaveChangesAsync();
                return player.PlayerId;
            }
            return 0;
        }
    
        public async Task<PlayerViewModel> GetPlayer(int? PlayerId)
        {
            if (db != null)
            {
                return await (from p in db.Players
                              join t in db.Teams on p.TeamId equals t.Id
                              where p.PlayerId == PlayerId
                              select new PlayerViewModel
                              {
                                  TeamID = t.Id,
                                  TeamLocation = t.Location,
                                  TeamName = t.Name,
                                  PlayerID = p.PlayerId,
                                  PlayerFirstName = p.FirstName,
                                  PlayerLastName = p.LastName
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<PlayerViewModel>> GetPlayersByLastName(string? LastName)
        {
            if (db != null)
            {
                return await (from p in db.Players
                              join t in db.Teams on p.TeamId equals t.Id
                              where p.LastName ==LastName
                              select new PlayerViewModel
                              {
                                  TeamID = t.Id,
                                  TeamLocation = t.Location,
                                  TeamName = t.Name,
                                  PlayerID = p.PlayerId,
                                  PlayerFirstName = p.FirstName,
                                  PlayerLastName = p.LastName
                              }).ToListAsync();
            }
            return null;
        }


        public async Task<List<PlayerViewModel>> GetTeamAndPlayers(int? TeamId)
        {
            if (db != null)
            {
                return await (from p in db.Players
                              join t in db.Teams on p.TeamId equals t.Id
                              where p.TeamId==TeamId
                              select new PlayerViewModel
                              {
                                  TeamID = t.Id,
                                  TeamLocation = t.Location,
                                  TeamName = t.Name,
                                  PlayerID = p.PlayerId,
                                  PlayerFirstName = p.FirstName,
                                  PlayerLastName = p.LastName
                              }).ToListAsync();
            }
            return null;
        }


        public async Task<List<PlayerViewModel>> GetAllPlayers()
        {
            if (db != null)
            {
                return await (from p in db.Players
                              join t in db.Teams on p.TeamId equals t.Id
                              select new PlayerViewModel
                              {
                                  TeamID = t.Id,
                                  TeamLocation = t.Location,
                                  TeamName = t.Name,
                                  PlayerID = p.PlayerId,
                                  PlayerFirstName = p.FirstName,
                                  PlayerLastName = p.LastName
                              }).ToListAsync();
            }
            return null;
        }
    

        public async Task UpdatePlayer(Players player)
        {
            if (db != null)
            {
                //Delete that post
                db.Players.Update(player);
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
