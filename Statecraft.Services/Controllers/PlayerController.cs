using AutoMapper;
using Statecraft.Common.Models;
using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Statecraft.Services.Controllers
{
    /// <summary>
    /// Create, start, and retrieve players.
    /// </summary>
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Route("players")]
    public class PlayerController : ApiController
    {
        private IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [Route("~/players/{playerId}")]
        public IHttpActionResult GetPlayerById(Guid playerId)
        {
            var player = _playerRepository.GetPlayerById(playerId);

            if(player == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Player>(player));
        }
    }
}
