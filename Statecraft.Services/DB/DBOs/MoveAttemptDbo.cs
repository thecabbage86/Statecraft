﻿using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statecraft.Services.DB.DBOs
{
    public class MoveAttemptDbo
    {
        public long Id { get; set; }
        public OrdersType OrdersType { get; set; }
        public long SelectedTerritoryId { get; set; }
        public long SupportedOrConvoyedTerritoryId { get; set; }
        public long DestinationTerritoryId { get; set; }
    }
}