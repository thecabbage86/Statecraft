using Statecraft.Common.Models;
using Statecraft.Services.DB.DBOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Statecraft.Services.DB
{
    public class GameContext : DbContext
    {
        public DbSet<GameDbo> Games { get; set; }
        public DbSet<TerritoryDbo> Territories { get; set; }

    }
}