using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Common.DTOs
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RankScore { get; set; }
        public int Reliability { get; set; }
    }
}