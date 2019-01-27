using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class JapaneseVillager : Villager
    {
        public JapaneseVillager() { }

        public override void SetAllowedBuildings()
        {
            allowedBuildings.AddRange(new List<ConstBuilding>
            {
                //Economic
                cBuilding.TownCenter,
                cBuilding.Shrine,
                cBuilding.Market,
                cBuilding.Consulate,
                cBuilding.Dock,
                
                //Military
                cBuilding.Barracks,
                cBuilding.Stable,
                cBuilding.Castle,

                //Wonders
                cBuilding.ToshoguShrine,
                cBuilding.GoldenPavilion,
                cBuilding.Shogunate,
                cBuilding.ToriiGates,
            });
        }
    }
}
