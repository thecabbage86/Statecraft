using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Statecraft.Common.DTOs
{
    public class OrdersDto
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Game")]
        public Guid GameId { get; set; }

        public int GameRoundId { get; set; }

        public OrdersType OrdersType { get; set; }

        public long SelectedTerritoryId { get; set; }

        public long SupportedOrConvoyedTerritoryId { get; set; }

        public long DestinationTerritoryId { get; set; }


        public virtual GameDto Game { get; set; }
    }
}