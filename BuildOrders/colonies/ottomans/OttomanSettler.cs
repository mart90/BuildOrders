using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class OttomanSettler : Villager
    {
        public override void SetAllowedBuildings()
        {
            allowedBuildings.AddRange(new List<ConstBuilding>
            {
                //Economic
                cBuilding.House,
                cBuilding.TradingPost,
                cBuilding.Market,
                cBuilding.Mosque,
                cBuilding.Dock,
                
                //Military
                cBuilding.Barracks,
                cBuilding.Stable,
                cBuilding.ArtilleryFoundry,
            });
        }
    }
}
