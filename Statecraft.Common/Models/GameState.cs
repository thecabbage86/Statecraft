using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Statecraft.Common.Models.Territories;
using Statecraft.Common.DTOs;

namespace Statecraft.Common.Models
{
    public class GameState
    {
        //public int GameId { get; set; }
        public GameRound Round { get; set; }
        //public IList<Territory> Territories { get; set; }
        public GameMap Map { get; set; }

        public GameState()
        { 
            Round = new GameRound(1) { Phase = Phase.Movement, Season = Season.Spring, Year = 1901 };
            InitializeMap(); //TODO: remove this call from here, only call it when the game is created; move InitializeMap to GameLogic
        }

        public GameState(int roundId, IList<TerritoryDto> territories)
        {
            Round = new GameRound(roundId);
            InitializeMap();
            foreach(var territory in Map.Territories)
            {
                var dto = territories.FirstOrDefault(t => t.Id == territory.Id);
                if(dto != null)
                {
                    if(dto.OccupyingUnitCountry == null)
                    {
                        territory.OccupyingUnit = null;
                    }
                    else
                    {
                        territory.OccupyingUnit = new Unit((Country)dto.OccupyingUnitCountry, (UnitType)dto.OccupyingUnitType);
                    }
                    
                }
            }
        }

        public void InitializeMap()
        {
            Map = new GameMap();

            Map.AddTerritory(new Territory(1, TerritoryName.Ankara, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(2, TerritoryName.Belgium, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(3, TerritoryName.Berlin, true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Land)));
            Map.AddTerritory(new Territory(4, TerritoryName.Brest, true, TerritoryType.Land, new Unit(Country.France, UnitType.Sea)));
            Map.AddTerritory(new Territory(5, TerritoryName.Budapest, true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Land)));
            Map.AddTerritory(new Territory(6, TerritoryName.Bulgaria, true, TerritoryType.Land, new List<Coast>() { new Coast(CoastType.East), new Coast(CoastType.South) }));
            Map.AddTerritory(new Territory(7, TerritoryName.Constantinople, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(8, TerritoryName.Denmark, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(9, TerritoryName.Edinburgh, true, TerritoryType.Land, new Unit(Country.England, UnitType.Sea)));
            Map.AddTerritory(new Territory(10, TerritoryName.Greece, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(11, TerritoryName.Holland, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(12, TerritoryName.Kiel, true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Sea)));
            Map.AddTerritory(new Territory(13, TerritoryName.Liverpool, true, TerritoryType.Land, new Unit(Country.England, UnitType.Land)));
            Map.AddTerritory(new Territory(14, TerritoryName.London, true, TerritoryType.Land, new Unit(Country.England, UnitType.Sea)));
            Map.AddTerritory(new Territory(15, TerritoryName.Marseilles, true, TerritoryType.Land, new Unit(Country.France, UnitType.Land)));
            Map.AddTerritory(new Territory(16, TerritoryName.Moscow, true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Land)));
            Map.AddTerritory(new Territory(17, TerritoryName.Munich, true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Land)));
            Map.AddTerritory(new Territory(18, TerritoryName.Naples, true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Sea)));
            Map.AddTerritory(new Territory(19, TerritoryName.Norway, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(20, TerritoryName.Paris, true, TerritoryType.Land, new Unit(Country.France, UnitType.Land)));
            Map.AddTerritory(new Territory(21, TerritoryName.Portugal, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(22, TerritoryName.Rome, true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Sea))); //*Italy may start with either a Fleet or Army in Rome.  Army is traditional, Fleet is recommended.
            Map.AddTerritory(new Territory(23, TerritoryName.Rumania, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(24, TerritoryName.SaintPetersburg, true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Sea), new List<Coast>() { new Coast(CoastType.North), new Coast(CoastType.South, true) }));
            Map.AddTerritory(new Territory(25, TerritoryName.Serbia, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(26, TerritoryName.Sevastopol, true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Sea)));
            Map.AddTerritory(new Territory(27, TerritoryName.Smyrna, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(28, TerritoryName.Spain, true, TerritoryType.Land, new List<Coast>() { new Coast(CoastType.North), new Coast(CoastType.South) }));
            Map.AddTerritory(new Territory(29, TerritoryName.Sweden, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(30, TerritoryName.Trieste, true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Sea)));
            Map.AddTerritory(new Territory(31, TerritoryName.Tunis, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(32, TerritoryName.Venice, true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Land)));
            Map.AddTerritory(new Territory(33, TerritoryName.Vienna, true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Land)));
            Map.AddTerritory(new Territory(34, TerritoryName.Warsaw, true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Land)));
            Map.AddTerritory(new Territory(35, TerritoryName.Clyde, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(36, TerritoryName.Yorkshire, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(37, TerritoryName.Wales, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(38, TerritoryName.Picardy, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(39, TerritoryName.Gascony, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(40, TerritoryName.Burgundy, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(41, TerritoryName.NorthAfrica, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(42, TerritoryName.Ruhr, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(43, TerritoryName.Prussia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(44, TerritoryName.Silesia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(45, TerritoryName.Piedmont, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(46, TerritoryName.Tuscany, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(47, TerritoryName.Apulia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(48, TerritoryName.Tyrolia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(49, TerritoryName.Galicia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(50, TerritoryName.Bohemia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(51, TerritoryName.Finland, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(52, TerritoryName.Livonia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(53, TerritoryName.Ukraine, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(54, TerritoryName.Albania, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(55, TerritoryName.Armenia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(56, TerritoryName.Syria, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(57, TerritoryName.NorthAtlanticOcean, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(58, TerritoryName.MidAtlanticOcean, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(59, TerritoryName.NorweigianSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(60, TerritoryName.NorthSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(61, TerritoryName.EnglishChannel, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(62, TerritoryName.IrishSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(63, TerritoryName.HeligolandBlight, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(64, TerritoryName.Skagerrak, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(65, TerritoryName.BalticSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(66, TerritoryName.GulfofBothnia, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(67, TerritoryName.BerentsSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(68, TerritoryName.WesternMediterranean, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(69, TerritoryName.GulfofLyonsn, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(70, TerritoryName.TyrrhenianSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(71, TerritoryName.IonianSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(72, TerritoryName.AdriaticSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(73, TerritoryName.AegeanSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(74, TerritoryName.EasternMediterranean, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(75, TerritoryName.BlackSea, false, TerritoryType.Sea));

            //Map.AddUndirectedEdge(TerritoryName.Ankara, TerritoryName.Smyrna);
            //Map.AddUndirectedEdge(TerritoryName.Ankara, TerritoryName.Constantinople);
            //Map.AddUndirectedEdge(TerritoryName.Ankara, TerritoryName.BlackSea);
            //Map.AddUndirectedEdge(TerritoryName.Ankara, TerritoryName.Armenia);

            Map.AddUndirectedEdge(TerritoryName.SaintPetersburg, TerritoryName.Norway);
            //Map.AddUndirectedEdge(TerritoryName.SaintPetersburg, TerritoryName.BerentsSea);
            //Map.AddUndirectedEdge(TerritoryName.SaintPetersburg, TerritoryName.Finland);
            //Map.AddUndirectedEdge(TerritoryName.SaintPetersburg, TerritoryName.Livonia);
            //Map.AddUndirectedEdge(TerritoryName.SaintPetersburg, TerritoryName.Moscow);
            //Map.AddUndirectedEdge(TerritoryName.SaintPetersburg, TerritoryName.GulfofBothnia);
        }
    }
}
