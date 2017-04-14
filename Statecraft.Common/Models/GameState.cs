using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Common.Models
{
    public class GameState
    {
        public IList<Territory> Territories { get; set; }
        //players

        public GameState()
        {
            Territories = new List<Territory>()
            {
                new Territory("Ankara", true, TerritoryType.Land),
                new Territory("Belgium", true, TerritoryType.Land),
                new Territory("Berlin", true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Land)),
                new Territory("Brest", true, TerritoryType.Land, new Unit(Country.France, UnitType.Sea)),
                new Territory("Budapest", true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Land)),
                new Territory("Bulgaria", true, TerritoryType.Land),
                new Territory("Constantinople", true, TerritoryType.Land),
                new Territory("Denmark", true, TerritoryType.Land),
                new Territory("Edinburgh", true, TerritoryType.Land, new Unit(Country.England, UnitType.Sea)),
                new Territory("Greece", true, TerritoryType.Land),
                new Territory("Holland", true, TerritoryType.Land),
                new Territory("Kiel", true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Sea)),
                new Territory("Liverpool", true, TerritoryType.Land, new Unit(Country.England, UnitType.Land)),
                new Territory("London", true, TerritoryType.Land, new Unit(Country.England, UnitType.Sea)),
                new Territory("Marseilles", true, TerritoryType.Land, new Unit(Country.France, UnitType.Land)),
                new Territory("Moscow", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Land)),
                new Territory("Munich", true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Land)),
                new Territory("Naples", true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Sea)),
                new Territory("Norway", true, TerritoryType.Land),
                new Territory("Paris", true, TerritoryType.Land, new Unit(Country.France, UnitType.Land)),
                new Territory("Portugal", true, TerritoryType.Land),
                new Territory("Rome", true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Sea)), //*Italy may start with either a Fleet or Army in Rome.  Army is traditional, Fleet is recommended.
                new Territory("Rumania", true, TerritoryType.Land),
                new Territory("St. Petersburg", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Sea), new List<Coast>() { new Coast(CoastType.North), new Coast(CoastType.South, true) }),
                new Territory("Serbia", true, TerritoryType.Land),
                new Territory("Sevastopol", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Sea)),
                new Territory("Smyrna", true, TerritoryType.Land),
                new Territory("Spain", true, TerritoryType.Land),
                new Territory("Sweden", true, TerritoryType.Land),
                new Territory("Trieste", true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Sea)),
                new Territory("Tunis", true, TerritoryType.Land),
                new Territory("Venice", true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Land)),
                new Territory("Vienna", true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Land)),
                new Territory("Warsaw", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Land)),
                new Territory("Yorkshire", false, TerritoryType.Land),
                new Territory("Wales", false, TerritoryType.Land),
                new Territory("Picardy", false, TerritoryType.Land),
                new Territory("Gascony", false, TerritoryType.Land),
                new Territory("Burgundy", false, TerritoryType.Land),
                new Territory("NorthAfrica", false, TerritoryType.Land),
                new Territory("Ruhr", false, TerritoryType.Land),
                new Territory("Prussia", false, TerritoryType.Land),
                new Territory("Silesia", false, TerritoryType.Land),
                new Territory("Piedmont", false, TerritoryType.Land),
                new Territory("Tuscany", false, TerritoryType.Land),
                new Territory("Apulia", false, TerritoryType.Land),
                new Territory("Tyrolia", false, TerritoryType.Land),
                new Territory("Galicia", false, TerritoryType.Land),
                new Territory("Bohemia", false, TerritoryType.Land),
                new Territory("Finland", false, TerritoryType.Land),
                new Territory("Livonia", false, TerritoryType.Land),
                new Territory("Ukraine", false, TerritoryType.Land),
                new Territory("Albania", false, TerritoryType.Land),
                new Territory("Armenia", false, TerritoryType.Land),
                new Territory("Syria", false, TerritoryType.Land),
                new Territory("NorthAtlanticOcean", false, TerritoryType.Sea),
                new Territory("MidAtlanticOcean", false, TerritoryType.Sea),
                new Territory("NorweigianSea", false, TerritoryType.Sea),
                new Territory("NorthSea", false, TerritoryType.Sea),
                new Territory("EnglishChannel", false, TerritoryType.Sea),
                new Territory("IrishSea", false, TerritoryType.Sea),
                new Territory("HeligolandBlight", false, TerritoryType.Sea),
                new Territory("Skagerrak", false, TerritoryType.Sea),
                new Territory("BalticSea", false, TerritoryType.Sea),
                new Territory("GulfofBothnia", false, TerritoryType.Sea),
                new Territory("BerentsSea", false, TerritoryType.Sea),
                new Territory("WesternMediterranean", false, TerritoryType.Sea),
                new Territory("GulfofLyonsn", false, TerritoryType.Sea),
                new Territory("TyrrhenianSea", false, TerritoryType.Sea),
                new Territory("IonianSea", false, TerritoryType.Sea),
                new Territory("AdriaticSea", false, TerritoryType.Sea),
                new Territory("AegeanSea", false, TerritoryType.Sea),
                new Territory("EasternMediterranean", false, TerritoryType.Sea),
                new Territory("BlackSea", false, TerritoryType.Sea)
            };
        }
    }
}
