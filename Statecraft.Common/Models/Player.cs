using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        //public int UserId { get; set; }
        //public Country Country { get; set; }
        public int RankScore { get; set; }
        public int Reliability { get; set; }
    }
}
