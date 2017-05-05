﻿using Statecraft.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Services.Interfaces
{
    public interface IOrdersRepository
    {
        void SaveOrders(int gameId, IList<MoveAttempt> orders);
    }
}