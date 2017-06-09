using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;
using Statecraft.Common.DTOs;

namespace Statecraft.Services.Repositories
{
    public class OrdersRepositoryFake : IOrdersRepository
    {
        public void SaveOrders(Guid gameId, IList<OrdersDto> orders)
        {
        }
    }
}