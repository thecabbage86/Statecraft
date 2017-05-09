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
    public class TerritoryUiData
    {
        private Dictionary<TerritoryName, Tuple<int, int>> territoryUnitCoordinates;
        private Dictionary<TerritoryName, int> territoryResourceIds;

        public TerritoryUiData()
        {
            territoryUnitCoordinates = new Dictionary<TerritoryName, Tuple<int, int>>();
            territoryUnitCoordinates.Add(TerritoryName.SaintPetersburg, new Tuple<int, int>(400, 100));
            territoryUnitCoordinates.Add(TerritoryName.BerentsSea, new Tuple<int, int>(400, 40));
            territoryUnitCoordinates.Add(TerritoryName.Ankara, new Tuple<int, int>(415, 380));
            //TODO: add coordinates for every territory

            territoryResourceIds = new Dictionary<TerritoryName, int>();
            territoryResourceIds.Add(TerritoryName.SaintPetersburg, Resource.Id.stPetersUnit);
            territoryResourceIds.Add(TerritoryName.BerentsSea, Resource.Id.berentsUnit);
            territoryResourceIds.Add(TerritoryName.Ankara, Resource.Id.ankaraUnit);
            //TODO: add for every territory
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

        public int GetResourceId(TerritoryName territory)
        {
            int resourceId;

            if (!territoryResourceIds.TryGetValue(territory, out resourceId))
            {
                //???
            }

            return resourceId;
        }
    }
}