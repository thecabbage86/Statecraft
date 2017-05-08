using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Statecraft.Common.Enums;

namespace Statecraft.App.UI
{
    //NOTE: coordinates are in dp (not px)
    public class TerritoryUnitCoordinates
    {
        private Dictionary<TerritoryName, Tuple<int, int>> territoryUnitCoordinates;

        public TerritoryUnitCoordinates()
        {
            territoryUnitCoordinates = new Dictionary<TerritoryName, Tuple<int, int>>();
            territoryUnitCoordinates.Add(TerritoryName.SaintPetersburg, new Tuple<int, int>(400, 100));
            territoryUnitCoordinates.Add(TerritoryName.BerentsSea, new Tuple<int, int>(400, 40));
            //TODO: add coordinates for every territory
        }

        public Tuple<int, int> GetCoordinates(TerritoryName territory)
        {
            Tuple<int, int> coordinates;

            if (!territoryUnitCoordinates.TryGetValue(territory, out coordinates))
            {
                //???
            }

            return coordinates;
        }
    }
}