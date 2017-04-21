using Statecraft.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Algorithms;

namespace Statecraft.Common.Models
{
    public class GameState
    {
        //public int GameId { get; set; }
        public GameRound Round { get; set; }
        public AdjacencyGraph<Territory, Edge<Territory>> Territories { get; set; }

        public GameState()
        {
            Round = new GameRound() { Phase = Phase.Movement, Season = Season.Spring, Year = 1901 };

            var ankara = new Territory("Ankara", true, TerritoryType.Land);
            var belgium = new Territory("Belgium", true, TerritoryType.Land);
            var berlin = new Territory("Berlin", true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Land));
            var brest = new Territory("Brest", true, TerritoryType.Land, new Unit(Country.France, UnitType.Sea));
            var budapest = new Territory("Budapest", true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Land));
            var bulgaria = new Territory("Bulgaria", true, TerritoryType.Land, new List<Coast>() { new Coast(CoastType.East), new Coast(CoastType.South) });
            var constantinople = new Territory("Constantinople", true, TerritoryType.Land);
            var denmark = new Territory("Denmark", true, TerritoryType.Land);
            var edinburgh = new Territory("Edinburgh", true, TerritoryType.Land, new Unit(Country.England, UnitType.Sea));
            var greece = new Territory("Greece", true, TerritoryType.Land);
            var holland = new Territory("Holland", true, TerritoryType.Land);
            var kiel = new Territory("Kiel", true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Sea));
            var liverpool = new Territory("Liverpool", true, TerritoryType.Land, new Unit(Country.England, UnitType.Land));
            var london = new Territory("London", true, TerritoryType.Land, new Unit(Country.England, UnitType.Sea));
            var marseilles = new Territory("Marseilles", true, TerritoryType.Land, new Unit(Country.France, UnitType.Land));
            var moscow = new Territory("Moscow", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Land));
            var munich = new Territory("Munich", true, TerritoryType.Land, new Unit(Country.Germany, UnitType.Land));
            var naples = new Territory("Naples", true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Sea));
            var norway = new Territory("Norway", true, TerritoryType.Land);
            var paris = new Territory("Paris", true, TerritoryType.Land, new Unit(Country.France, UnitType.Land));
            var portugal = new Territory("Portugal", true, TerritoryType.Land);
            var rome = new Territory("Rome", true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Sea)); //*Italy may start with either a Fleet or Army in Rome.  Army is traditional, Fleet is recommended.
            var rumania = new Territory("Rumania", true, TerritoryType.Land);
            var stPetersburg = new Territory("St. Petersburg", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Sea), new List<Coast>() { new Coast(CoastType.North), new Coast(CoastType.South, true) });
            var serbia = new Territory("Serbia", true, TerritoryType.Land);
            var sevastopol = new Territory("Sevastopol", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Sea));
            var smyrna = new Territory("Smyrna", true, TerritoryType.Land);
            var spain = new Territory("Spain", true, TerritoryType.Land, new List<Coast>() { new Coast(CoastType.North), new Coast(CoastType.South) });
            var sweden = new Territory("Sweden", true, TerritoryType.Land);
            var trieste = new Territory("Trieste", true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Sea));
            var tunis = new Territory("Tunis", true, TerritoryType.Land);
            var venice = new Territory("Venice", true, TerritoryType.Land, new Unit(Country.Italy, UnitType.Land));
            var vienna = new Territory("Vienna", true, TerritoryType.Land, new Unit(Country.Austria, UnitType.Land));
            var warsaw = new Territory("Warsaw", true, TerritoryType.Land, new Unit(Country.Russia, UnitType.Land));
            var clyde = new Territory("Clyde", false, TerritoryType.Land);
            var yorkshire = new Territory("Yorkshire", false, TerritoryType.Land);
            var wales = new Territory("Wales", false, TerritoryType.Land);
            var picardy = new Territory("Picardy", false, TerritoryType.Land);
            var gascony = new Territory("Gascony", false, TerritoryType.Land);
            var burgundy = new Territory("Burgundy", false, TerritoryType.Land);
            var northAfrica = new Territory("NorthAfrica", false, TerritoryType.Land);
            var ruhr = new Territory("Ruhr", false, TerritoryType.Land);
            var prussia = new Territory("Prussia", false, TerritoryType.Land);
            var silesia = new Territory("Silesia", false, TerritoryType.Land);
            var piedmont = new Territory("Piedmont", false, TerritoryType.Land);
            var tuscany = new Territory("Tuscany", false, TerritoryType.Land);
            var apulia = new Territory("Apulia", false, TerritoryType.Land);
            var tyrolia = new Territory("Tyrolia", false, TerritoryType.Land);
            var galicia = new Territory("Galicia", false, TerritoryType.Land);
            var bohemia = new Territory("Bohemia", false, TerritoryType.Land);
            var finland = new Territory("Finland", false, TerritoryType.Land);
            var livonia = new Territory("Livonia", false, TerritoryType.Land);
            var ukraine = new Territory("Ukraine", false, TerritoryType.Land);
            var albania = new Territory("Albania", false, TerritoryType.Land);
            var armenia = new Territory("Armenia", false, TerritoryType.Land);
            var syria = new Territory("Syria", false, TerritoryType.Land);
            var northAtlanticOcean = new Territory("NorthAtlanticOcean", false, TerritoryType.Sea);
            var midAtlanticOcean = new Territory("MidAtlanticOcean", false, TerritoryType.Sea);
            var norweigianSea = new Territory("NorweigianSea", false, TerritoryType.Sea);
            var northSea = new Territory("NorthSea", false, TerritoryType.Sea);
            var englishChannel = new Territory("EnglishChannel", false, TerritoryType.Sea);
            var irishSea = new Territory("IrishSea", false, TerritoryType.Sea);
            var heligolandBlight = new Territory("HeligolandBlight", false, TerritoryType.Sea);
            var skagerrak = new Territory("Skagerrak", false, TerritoryType.Sea);
            var balticSea = new Territory("BalticSea", false, TerritoryType.Sea);
            var gulfofBothnia = new Territory("GulfofBothnia", false, TerritoryType.Sea);
            var berentsSea = new Territory("BerentsSea", false, TerritoryType.Sea);
            var westernMediterranean = new Territory("WesternMediterranean", false, TerritoryType.Sea);
            var gulfofLyon = new Territory("GulfofLyon", false, TerritoryType.Sea);
            var tyrrhenianSea = new Territory("TyrrhenianSea", false, TerritoryType.Sea);
            var ionianSea = new Territory("IonianSea", false, TerritoryType.Sea);
            var adriaticSea = new Territory("AdriaticSea", false, TerritoryType.Sea);
            var aegeanSea = new Territory("AegeanSea", false, TerritoryType.Sea);
            var easternMediterranean = new Territory("EasternMediterranean", false, TerritoryType.Sea);
            var blackSea = new Territory("BlackSea", false, TerritoryType.Sea);

            var connections = new Edge<Territory>[] {
                new Edge<Territory>(northAtlanticOcean, norweigianSea),
                new Edge<Territory>(northAtlanticOcean, irishSea),
                new Edge<Territory>(northAtlanticOcean, midAtlanticOcean),
                new Edge<Territory>(northAtlanticOcean, clyde),
                new Edge<Territory>(norweigianSea, berentsSea),
                new Edge<Territory>(norweigianSea, norway),
                new Edge<Territory>(norweigianSea, northSea),
                new Edge<Territory>(norweigianSea, clyde),
                new Edge<Territory>(norweigianSea, edinburgh),
                new Edge<Territory>(berentsSea, stPetersburg),
                new Edge<Territory>(berentsSea, norway),
                new Edge<Territory>(stPetersburg, norway),
                new Edge<Territory>(stPetersburg, finland),
                new Edge<Territory>(stPetersburg, livonia),
                new Edge<Territory>(stPetersburg, moscow),
                new Edge<Territory>(stPetersburg, gulfofBothnia),
                new Edge<Territory>(finland, norway),
                new Edge<Territory>(finland, sweden),
                new Edge<Territory>(finland, gulfofBothnia),
                new Edge<Territory>(sweden, norway),
                new Edge<Territory>(sweden, gulfofBothnia),
                new Edge<Territory>(sweden, balticSea),
                new Edge<Territory>(sweden, denmark),
                new Edge<Territory>(sweden, skagerrak),
                new Edge<Territory>(gulfofBothnia, balticSea),
                new Edge<Territory>(gulfofBothnia, livonia),
                new Edge<Territory>(norway, skagerrak),
                new Edge<Territory>(norway, northSea),
                new Edge<Territory>(balticSea, livonia),
                new Edge<Territory>(balticSea, prussia),
                new Edge<Territory>(balticSea, berlin),
                new Edge<Territory>(balticSea, kiel),
                new Edge<Territory>(balticSea, denmark),
                new Edge<Territory>(skagerrak, denmark),
                new Edge<Territory>(skagerrak, northSea),
                new Edge<Territory>(heligolandBlight, denmark),
                new Edge<Territory>(heligolandBlight, kiel),
                new Edge<Territory>(heligolandBlight, holland),
                new Edge<Territory>(heligolandBlight, northSea),
                new Edge<Territory>(northSea, denmark),
                new Edge<Territory>(northSea, holland),
                new Edge<Territory>(northSea, belgium),
                new Edge<Territory>(northSea, englishChannel),
                new Edge<Territory>(northSea, london),
                new Edge<Territory>(northSea, yorkshire),
                new Edge<Territory>(northSea, edinburgh),
                new Edge<Territory>(englishChannel, london),
                new Edge<Territory>(englishChannel, wales),
                new Edge<Territory>(englishChannel, irishSea),
                new Edge<Territory>(englishChannel, midAtlanticOcean),
                new Edge<Territory>(englishChannel, belgium),
                new Edge<Territory>(englishChannel, picardy),
                new Edge<Territory>(englishChannel, brest),
                new Edge<Territory>(irishSea, wales),
                new Edge<Territory>(irishSea, liverpool),
                new Edge<Territory>(irishSea, midAtlanticOcean),
                new Edge<Territory>(midAtlanticOcean, brest),
                new Edge<Territory>(midAtlanticOcean, gascony),
                new Edge<Territory>(midAtlanticOcean, spain),
                new Edge<Territory>(midAtlanticOcean, portugal),
                new Edge<Territory>(midAtlanticOcean, westernMediterranean),
                new Edge<Territory>(midAtlanticOcean, northAfrica),
                //TODO: finish 
            };

            Territories = connections.ToAdjacencyGraph<Territory, Edge<Territory>>();
        }
    }
}
