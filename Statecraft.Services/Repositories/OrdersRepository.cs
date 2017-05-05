using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;

namespace Statecraft.Services.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public void SaveOrders(int gameId, IList<MoveAttempt> orders)
        {
            throw new NotImplementedException();
        }
    }
}