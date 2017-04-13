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
                new Territory("Ankara", true),
                new Territory("Belgium", true),
                new Territory("Berlin", true),
                new Territory("Brest", true),
                new Territory("Budapest", true),
                new Territory("Bulgaria", true),
                new Territory("Constantinople", true),
                new Territory("Denmark", true),
                new Territory("Edinburgh", true),
                new Territory("Greece", true),
                new Territory("Holland", true),
                new Territory("Kiel", true),
                new Territory("Liverpool", true),
                new Territory("London", true),
                new Territory("Marseilles", true),
                new Territory("Moscow", true),
                new Territory("Munich", true),
                new Territory("Naples", true),
                new Territory("Norway", true),
                new Territory("Paris", true),
                new Territory("Portugal", true),
                new Territory("Rome", true),
                new Territory("Rumania", true),
                new Territory("St. Petersburg", true),
                new Territory("Serbia", true),
                new Territory("Sevastopol", true),
                new Territory("Smyrna", true),
                new Territory("Spain", true),
                new Territory("Sweden", true),
                new Territory("Trieste", true),
                new Territory("Tunis", true),
                new Territory("Venice", true),
                new Territory("Vienna", true),
                new Territory("Warsaw", true)
            };
        }
    }
}
