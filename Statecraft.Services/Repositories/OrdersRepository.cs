using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;
using Statecraft.Services.DB;
using Statecraft.Common.DTOs;

namespace Statecraft.Services.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public void SaveOrders(Guid gameId, IList<OrdersDto> orders)
        {
            using (var context = new GameContext())
            {
                context.Orders.AddRange(orders);
            }
        }
    }
}