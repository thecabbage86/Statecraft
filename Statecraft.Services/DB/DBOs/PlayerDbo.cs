using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Services.DB.DBOs
{
    public class PlayerDbo
    {
        public Guid Id { get; set; }
        public int RankScore { get; set; }
        public int Reliability { get; set; }
    }
}