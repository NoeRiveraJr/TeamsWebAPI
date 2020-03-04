using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamAPI.Models;
using TeamAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TeamAPI.Controllers
{
    [Route("api/Player")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPlayerRepository playerRepository;
        public PostController(IPlayerRepository _playerRepository)
        {
            playerRepository = _playerRepository;
        }

        [HttpGet]
        [Route("GetAllPlayers")]
        public async Task<IActionResult> GetAllPlayers()
        {
            try
            {
                var posts = await playerRepository.GetAllPlayers();
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
        [Route("GetTeamAndPlayers")]
        public async Task<IActionResult> GetTeamAndPlayers(int? TeamId)
        {
            try
            {
                var posts = await playerRepository.GetTeamAndPlayers(TeamId);
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
        [Route("GetPlayerById")]
        public async Task<IActionResult> GetPlayerById(int? playerId)
        {
            if (playerId == null)
            {
                return BadRequest();
            }
            try
            {
                var post = await playerRepository.GetPlayer(playerId);
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

        [HttpGet]
        [Route("GetPlayersByLastName")]
        public async Task<IActionResult> GetPlayersByLastName(string? LastName)
        {
            if (LastName == null)
            {
                return BadRequest();
            }
            try
            {
                var post = await playerRepository.GetPlayersByLastName(LastName);
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
        [Route("AddPlayer")]
        public async Task<IActionResult> AddPlayer([FromBody]Players player)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await playerRepository.AddPlayer(player);
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

        [HttpPut]
        [Route("UpdatePlayer")]
        public async Task<IActionResult> UpdatePlayer([FromBody]Players player)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await playerRepository.UpdatePlayer(player);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                     "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyExcepion")
                {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}