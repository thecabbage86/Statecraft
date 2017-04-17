﻿using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Services.Models.Requests
{
    public class UpdateGameStateRequest
    {
        public UpdateGameStateModel UpdateGameState { get; set; }
    }

    public class UpdateGameStateModel
    {
        public int GameId { get; set; }
        public GameState GameState { get; set; }
    }
}