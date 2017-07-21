using System;

namespace BuildOrders
{
    [Serializable]
    public class IndianVillager : Villager
    {
        public IndianVillager() { }

        public override void SetAllowedBuildings()
        {
            ConstBuilding[] allowedbuildings =
            {
                //Economic
                cBuilding.TownCenter,
                cBuilding.IndianHouse,
                cBuilding.Market,
                cBuilding.Consulate,
                
                //Military
                cBuilding.Barracks,
                cBuilding.Caravanserai,
                cBuilding.Castle,

                //Wonders
                cBuilding.AgraFort,
                cBuilding.CharminarGate,
                cBuilding.KarniMata,
                cBuilding.TowerOfVictory,
                cBuilding.TajMahal,
            };

            allowedBuildings.AddRange(allowedbuildings);
        }
    }
}
