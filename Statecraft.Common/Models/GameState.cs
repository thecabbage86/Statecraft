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
            Round = new GameRound() { Phase = Phase.Movement, Season = Season.Spring, Year = 1901 };

            Map = new GameMap();

            Map.AddTerritory(new Territory("Ankara", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Belgium", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Berlin", true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Land)));
            Map.AddTerritory(new Territory("Brest", true, TerritoryType.Land, new Unit(Country.France, UnitType.Sea)));
            Map.AddTerritory(new Territory("Budapest", true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Land)));
            Map.AddTerritory(new Territory("Bulgaria", true, TerritoryType.Land, new List<Coast>() { new Coast(CoastType.East), new Coast(CoastType.South) }));
            Map.AddTerritory(new Territory("Constantinople", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Denmark", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Edinburgh", true, TerritoryType.Land, new Unit(Country.England, UnitType.Sea)));
            Map.AddTerritory(new Territory("Greece", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Holland", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Kiel", true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Sea)));
            Map.AddTerritory(new Territory("Liverpool", true, TerritoryType.Land, new Unit(Country.England, UnitType.Land)));
            Map.AddTerritory(new Territory("London", true, TerritoryType.Land, new Unit(Country.England, UnitType.Sea)));
            Map.AddTerritory(new Territory("Marseilles", true, TerritoryType.Land, new Unit(Country.France, UnitType.Land)));
            Map.AddTerritory(new Territory("Moscow", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Land)));
            Map.AddTerritory(new Territory("Munich", true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Land)));
            Map.AddTerritory(new Territory("Naples", true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Sea)));
            Map.AddTerritory(new Territory("Norway", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Paris", true, TerritoryType.Land, new Unit(Country.France, UnitType.Land)));
            Map.AddTerritory(new Territory("Portugal", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Rome", true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Sea))); //*Italy may start with either a Fleet or Army in Rome.  Army is traditional, Fleet is recommended.
            Map.AddTerritory(new Territory("Rumania", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("St. Petersburg", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Sea), new List<Coast>() { new Coast(CoastType.North), new Coast(CoastType.South, true) }));
            Map.AddTerritory(new Territory("Serbia", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Sevastopol", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Sea)));
            Map.AddTerritory(new Territory("Smyrna", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Spain", true, TerritoryType.Land, new List<Coast>() { new Coast(CoastType.North), new Coast(CoastType.South) }));
            Map.AddTerritory(new Territory("Sweden", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Trieste", true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Sea)));
            Map.AddTerritory(new Territory("Tunis", true, TerritoryType.Land));
            Map.AddTerritory(new Territory("Venice", true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Land)));
            Map.AddTerritory(new Territory("Vienna", true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Land)));
            Map.AddTerritory(new Territory("Warsaw", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Land)));
            Map.AddTerritory(new Territory("Yorkshire", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Wales", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Picardy", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Gascony", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Burgundy", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("NorthAfrica", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Ruhr", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Prussia", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Silesia", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Piedmont", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Tuscany", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Apulia", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Tyrolia", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Galicia", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Bohemia", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Finland", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Livonia", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Ukraine", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Albania", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Armenia", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("Syria", false, TerritoryType.Land));
            Map.AddTerritory(new Territory("NorthAtlanticOcean", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("MidAtlanticOcean", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("NorweigianSea", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("NorthSea", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("EnglishChannel", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("IrishSea", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("HeligolandBlight", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("Skagerrak", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("BalticSea", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("GulfofBothnia", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("BerentsSea", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("WesternMediterranean", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("GulfofLyonsn", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("TyrrhenianSea", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("IonianSea", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("AdriaticSea", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("AegeanSea", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("EasternMediterranean", false, TerritoryType.Sea));
            Map.AddTerritory(new Territory("BlackSea", false, TerritoryType.Sea));
        }
    }
}
