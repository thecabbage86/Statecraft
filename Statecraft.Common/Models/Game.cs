using Statecraft.Common.DTOs;
using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public GameOptions Options { get; set; }
        public GameState CurrentGameState { get; set; }
        public bool HasBegun { get; set; }
        public bool IsFinished { get; set; }
        //public IList<Player> Players { get; set; }
        public Guid CreatorPlayerId { get; set; }
        public Guid? EnglandPlayerId { get; set; }
        public Guid? FrancePlayerId { get; set; }
        public Guid? ItalyPlayerId { get; set; }
        public Guid? RussiaPlayerId { get; set; }
        public Guid? AustriaPlayerId { get; set; }
        public Guid? TurkeyPlayerId { get; set; }
        public Guid? GermanyPlayerId { get; set; }
        public IList<Country> Winners { get; set; }

        public Game()
        {
            //CurrentGameState = new GameState();
        }

        public Game(GameDto dto)
        {
            Id = dto.Id;
            Options = new GameOptions() { IsGunboat = dto.IsGunboatOption, IsRanked = dto.IsRankedOption, RoundLength = dto.RoundLengthOption };
            CurrentGameState = new GameState(dto.GameRoundId, dto.Map);
            HasBegun = dto.HasBegun;
            IsFinished = dto.IsFinished;
            CreatorPlayerId = dto.CreatorPlayerId;
            EnglandPlayerId = dto.EnglandPlayerId;
            FrancePlayerId = dto.FrancePlayerId;
            ItalyPlayerId = dto.ItalyPlayerId;
            RussiaPlayerId = dto.RussiaPlayerId;
            AustriaPlayerId = dto.AustriaPlayerId;
            TurkeyPlayerId = dto.TurkeyPlayerId;
            GermanyPlayerId = dto.GermanyPlayerId;
            Winners = dto.Winners;
        }
    }
}
