using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Statecraft.Common.Models.Territories;

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

        public void InitializeMap()
        {
            Map = new GameMap();

            Map.AddTerritory(new Territory(TerritoryName.Ankara, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Belgium, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Berlin, true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Land)));
            Map.AddTerritory(new Territory(TerritoryName.Brest, true, TerritoryType.Land, new Unit(Country.France, UnitType.Sea)));
            Map.AddTerritory(new Territory(TerritoryName.Budapest, true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Land)));
            Map.AddTerritory(new Territory(TerritoryName.Bulgaria, true, TerritoryType.Land, new List<Coast>() { new Coast(CoastType.East), new Coast(CoastType.South) }));
            Map.AddTerritory(new Territory(TerritoryName.Constantinople, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Denmark, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Edinburgh, true, TerritoryType.Land, new Unit(Country.England, UnitType.Sea)));
            Map.AddTerritory(new Territory(TerritoryName.Greece, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Holland, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Kiel, true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Sea)));
            Map.AddTerritory(new Territory(TerritoryName.Liverpool, true, TerritoryType.Land, new Unit(Country.England, UnitType.Land)));
            Map.AddTerritory(new Territory(TerritoryName.London, true, TerritoryType.Land, new Unit(Country.England, UnitType.Sea)));
            Map.AddTerritory(new Territory(TerritoryName.Marseilles, true, TerritoryType.Land, new Unit(Country.France, UnitType.Land)));
            Map.AddTerritory(new Territory(TerritoryName.Moscow, true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Land)));
            Map.AddTerritory(new Territory(TerritoryName.Munich, true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Land)));
            Map.AddTerritory(new Territory(TerritoryName.Naples, true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Sea)));
            Map.AddTerritory(new Territory(TerritoryName.Norway, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Paris, true, TerritoryType.Land, new Unit(Country.France, UnitType.Land)));
            Map.AddTerritory(new Territory(TerritoryName.Portugal, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Rome, true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Sea))); //*Italy may start with either a Fleet or Army in Rome.  Army is traditional, Fleet is recommended.
            Map.AddTerritory(new Territory(TerritoryName.Rumania, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.SaintPetersburg, true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Sea), new List<Coast>() { new Coast(CoastType.North), new Coast(CoastType.South, true) }));
            Map.AddTerritory(new Territory(TerritoryName.Serbia, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Sevastopol, true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Sea)));
            Map.AddTerritory(new Territory(TerritoryName.Smyrna, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Spain, true, TerritoryType.Land, new List<Coast>() { new Coast(CoastType.North), new Coast(CoastType.South) }));
            Map.AddTerritory(new Territory(TerritoryName.Sweden, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Trieste, true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Sea)));
            Map.AddTerritory(new Territory(TerritoryName.Tunis, true, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Venice, true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Land)));
            Map.AddTerritory(new Territory(TerritoryName.Vienna, true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Land)));
            Map.AddTerritory(new Territory(TerritoryName.Warsaw, true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Land)));
            Map.AddTerritory(new Territory(TerritoryName.Yorkshire, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Wales, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Picardy, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Gascony, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Burgundy, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.NorthAfrica, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Ruhr, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Prussia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Silesia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Piedmont, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Tuscany, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Apulia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Tyrolia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Galicia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Bohemia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Finland, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Livonia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Ukraine, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Albania, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Armenia, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.Syria, false, TerritoryType.Land));
            Map.AddTerritory(new Territory(TerritoryName.NorthAtlanticOcean, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.MidAtlanticOcean, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.NorweigianSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.NorthSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.EnglishChannel, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.IrishSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.HeligolandBlight, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.Skagerrak, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.BalticSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.GulfofBothnia, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.BerentsSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.WesternMediterranean, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.GulfofLyonsn, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.TyrrhenianSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.IonianSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.AdriaticSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.AegeanSea, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.EasternMediterranean, false, TerritoryType.Sea));
            Map.AddTerritory(new Territory(TerritoryName.BlackSea, false, TerritoryType.Sea));

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
