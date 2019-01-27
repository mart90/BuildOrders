using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class IroquoisVillager : Villager
    {
        public override void SetAllowedBuildings()
        {
            allowedBuildings.AddRange(new List<ConstBuilding>
            {
                //Economic
                cBuilding.TownCenter,
                cBuilding.Market,
                cBuilding.FirePit,
                cBuilding.TradingPost,
                cBuilding.Longhouse,
                cBuilding.Dock,

                //Military
                cBuilding.WarHut,
                cBuilding.Corral,
                cBuilding.ArtilleryFoundry,
            });
        }
    }
}
