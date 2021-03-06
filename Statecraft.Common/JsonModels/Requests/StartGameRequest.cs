﻿using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Common.JsonModels.Requests
{
    public class StartGameRequest
    {
        public StartGameModel StartGame { get; set; }
    }

    public class StartGameModel
    {
        public Guid GameId { get; set; }
        public Guid? EnglandPlayerId { get; set; }
        public Guid? FrancePlayerId { get; set; }
        public Guid? ItalyPlayerId { get; set; }
        public Guid? RussiaPlayerId { get; set; }
        public Guid? AustriaPlayerId { get; set; }
        public Guid? TurkeyPlayerId { get; set; }
        public Guid? GermanyPlayerId { get; set; }
        public GameOptions Options { get; set; }
    }
}