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
    public class TerritoryUnitCoordinates
    {
        private Dictionary<TerritoryName, KeyValuePair<int, int>> territoryUnitCoordinates;

        public TerritoryUnitCoordinates()
        {
            territoryUnitCoordinates = new Dictionary<TerritoryName, KeyValuePair<int, int>>();
            territoryUnitCoordinates.Add(TerritoryName.SaintPetersburg, new KeyValuePair<int, int>(1400, 200));
            territoryUnitCoordinates.Add(TerritoryName.BerentsSea, new KeyValuePair<int, int>(1400, 40));
        }

        public KeyValuePair<int, int> GetCoordinates(TerritoryName territory)
        {
            KeyValuePair<int, int> coordinates;

            if (!territoryUnitCoordinates.TryGetValue(territory, out coordinates))
            {
                //???
            }

            return coordinates;
        }
    }
}