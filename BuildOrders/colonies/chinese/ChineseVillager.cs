using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class ChineseVillager : Villager
    {
        public ChineseVillager() { }

        public override void SetAllowedBuildings()
        {
            allowedBuildings.AddRange(new List<ConstBuilding>
            {
                //Economic
                cBuilding.TownCenter,
                cBuilding.Village,
                cBuilding.Market,
                cBuilding.Consulate,
                
                //Military
                cBuilding.WarAcademy,
                cBuilding.Castle,

                //Wonders
                cBuilding.PorcelainTower,
                cBuilding.WhitePagoda,
                cBuilding.SummerPalace,
                cBuilding.ConfucianAcademy,
                cBuilding.TempleOfHeaven,
            });
        }
    }
}
