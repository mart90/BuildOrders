using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class SiouxVillager : Villager
    {
        public override void SetAllowedBuildings()
        {
            allowedBuildings.AddRange(new List<ConstBuilding>
            {
                //Economic
                cBuilding.TownCenter,
                cBuilding.FirePit,
                cBuilding.TradingPost,
                cBuilding.Market,

                //Military
                cBuilding.WarHut,
                cBuilding.Corral,
            });
        }
    }
}
