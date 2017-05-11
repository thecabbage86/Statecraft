using Statecraft.Common.DTOs;
using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Statecraft.Services.DB
{
    public class GameContext : DbContext
    {
        public DbSet<GameDto> Games { get; set; }
        public DbSet<TerritoryDto> Territories { get; set; }

    }
}