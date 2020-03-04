using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamAPI.Models;
using TeamAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TeamAPI.Controllers
{
    [Route("api/Team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        ITeamRepository teamRepository;

        public TeamController(ITeamRepository _teamRepository)
        {
            teamRepository = _teamRepository;
        }

        [HttpGet]
        [Route("GetAllTeams")]
        public async Task<IActionResult> GetAllTeams()
        {
            try
            {
                var posts = await teamRepository.GetAllTeams();
                if (posts == null)
                {
                    return NotFound();
                }
                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetTeamById")]
        public async Task<IActionResult> GetTeamById(int? teamId)
        {
            if (teamId == null)
            {
                return BadRequest();
            }
            try
            {
                var post = await teamRepository.GetTeam(teamId);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddTeam")]
        public async Task<IActionResult> AddTeam([FromBody]Teams team)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await teamRepository.AddTeam(team);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllTeamsOrderedByName")]
        public async Task<IActionResult> GetAllTeamsOrderedByName()
        {
            try
            {
                var posts = await teamRepository.GetAllTeamsOrderedByName();
                if (posts == null)
                {
                    return NotFound();
                }
                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAllTeamsOrderedByLocation")]
        public async Task<IActionResult> GetAllTeamsOrderedByLocation()
        {
            try
            {
                var posts = await teamRepository.GetAllTeamsOrderedByLocation();
                if (posts == null)
                {
                    return NotFound();
                }
                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}