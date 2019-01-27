﻿using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class PortugueseSettler : Villager
    {
        public override void SetAllowedBuildings()
        {
            allowedBuildings.AddRange(new List<ConstBuilding>
            {
                //Economic
                cBuilding.House,
                cBuilding.TradingPost,
                cBuilding.Market,
                cBuilding.Dock,

                //Military
                cBuilding.Barracks,
                cBuilding.Stable,
                cBuilding.ArtilleryFoundry,
            });
        }
    }
}
