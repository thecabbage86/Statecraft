using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.JsonModels.Requests
{
    public class SaveOrdersRequest
    {
        public int GameId { get; set; }
        public IList<MoveAttempt> Orders { get; set; }

        public SaveOrdersRequest() { }

        public SaveOrdersRequest(int gameId, MoveAttempt order)
        {
            GameId = gameId;
            Orders = new List<MoveAttempt>() { order };
        }
    }
}
