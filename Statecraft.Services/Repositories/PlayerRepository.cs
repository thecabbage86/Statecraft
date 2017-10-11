using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.DTOs;
using Statecraft.Services.DB;

namespace Statecraft.Services.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerDto GetPlayerById(Guid playerId)
        {
            PlayerDto player = null;

            using (var context = new GameContext())
            {
                player = context.Players.FirstOrDefault(p => p.Id == playerId);
            }

            return player;
        }
    }
}