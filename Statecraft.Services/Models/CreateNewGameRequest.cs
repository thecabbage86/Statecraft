using Statecraft.Common.Enums;
using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Services.Models
{
    public class CreateNewGameRequest
    {
        public CreateNewGameModel StartGame { get; set; }
    }

    public class CreateNewGameModel
    {
        public Guid FirstPlayerId { get; set; }
        public Country SelectedCountry { get; set; }
        public GameOptions Options { get; set; }
    }
}