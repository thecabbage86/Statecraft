using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;

namespace Statecraft.Services.Repositories
{
    public class OrdersRepositoryFake : IOrdersRepository
    {
        public void SaveOrders(Guid gameId, IList<MoveAttempt> orders)
        {
        }
    }
}