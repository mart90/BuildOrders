using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class JapaneseExplorer : Explorer
    {
        public JapaneseExplorer() { }

        public override void SetAllowedBuildings()
        {
            allowedBuildings.AddRange(new List<ConstBuilding>
            {
                cBuilding.TownCenter,
                cBuilding.TradingPost,
                cBuilding.Shrine,
            });
        }
    }
}
