using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class GermanSettler : Villager
    {
        public override void SetAllowedBuildings()
        {
            allowedBuildings.AddRange(new List<ConstBuilding>
            {
                //Economic
                cBuilding.House,
                cBuilding.TradingPost,
                cBuilding.Market,
                
                //Military
                cBuilding.Barracks,
                cBuilding.Stable,
                cBuilding.ArtilleryFoundry,
            });
        }
    }
}
