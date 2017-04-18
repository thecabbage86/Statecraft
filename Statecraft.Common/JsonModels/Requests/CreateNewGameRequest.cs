using Statecraft.Common.Enums;
using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Common.JsonModels.Requests
{
    public class CreateNewGameRequest
    {
        public CreateNewGameModel CreateGame { get; set; }
    }

    public class CreateNewGameModel
    {
        public Guid FirstPlayerId { get; set; }
        public Country SelectedCountry { get; set; }
        public GameOptions Options { get; set; }
    }
}