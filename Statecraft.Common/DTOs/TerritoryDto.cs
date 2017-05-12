using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statecraft.Common.DTOs
{
    public class TerritoryDto
    {
        [Key, Column(Order =0)]
        public int Id { get; set; }
        [Key, Column(Order = 1), ForeignKey("Game")]
        public Guid GameId { get; set; }
        [Key, Column(Order = 2)]
        public int GameRoundId { get; set; }

        public UnitType? OccupyingUnitType { get; set; }
        public Country? OccupyingUnitCountry { get; set; }
        public Country? Owner { get; set; }

        public virtual GameDto Game { get; set; }
    }
}