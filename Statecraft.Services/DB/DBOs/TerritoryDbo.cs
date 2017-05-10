using Statecraft.Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statecraft.Services.DB.DBOs
{
    public class TerritoryDbo
    {
        [Key, Column(Order =0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Key, Column(Order = 1), ForeignKey("GameDbo")]
        public int GameId { get; set; }
        [Key, Column(Order = 2)]
        public int GameRoundId { get; set; }

        public UnitType OccupyingUnitType { get; set; }
        public Country OccupyingUnitCountry { get; set; }
        public Country Owner { get; set; }
    }
}