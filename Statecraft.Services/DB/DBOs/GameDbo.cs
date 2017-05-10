using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Services.DB.DBOs
{
    public class GameDbo
    {
        public Guid Id { get; set; }
        public bool IsGunboatOption { get; set; }
        public bool IsRankedOption { get; set; }
        public TimeSpan RoundLengthOption { get; set; }
        public bool HasBegun { get; set; }
        public bool IsFinished { get; set; }
        public Guid CreatorPlayerId { get; set; }
        public Guid? EnglandPlayerId { get; set; }
        public Guid? FrancePlayerId { get; set; }
        public Guid? ItalyPlayerId { get; set; }
        public Guid? RussiaPlayerId { get; set; }
        public Guid? AustriaPlayerId { get; set; }
        public Guid? TurkeyPlayerId { get; set; }
        public Guid? GermanyPlayerId { get; set; }
        public IList<Country> Winners { get; set; }

        public int GameRoundId { get; set; }
        public virtual IList<TerritoryDbo> Map { get; set; }
    }
}