using AutoMapper;
using Statecraft.Common.Constants;
using Statecraft.Common.DTOs;
using Statecraft.Common.JsonModels.Requests;
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
            Player player;

            try
            {
                var playerDto = _playerRepository.GetPlayerById(playerId);

                if (playerDto == null)
                {
                    return NotFound();
                }

                player = Mapper.Map<Player>(playerDto);
            }
            catch (Exception ex)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Ok(player);
        }

        [Route("~/players")]
        [HttpPost]
        public IHttpActionResult CreatePlayer(CreatePlayerRequest createPlayerRequest)
        {
            Player player;

            try
            {
                var playerDto = _playerRepository.CreatePlayer(new PlayerDto() { Name = createPlayerRequest.Name, RankScore = PlayerValues.DEFAULT_RANK_SCORE, Reliability = PlayerValues.DEFAULT_RELIABILITY });
                player = Mapper.Map<Player>(playerDto);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Ok(player);
        }
    }
}
