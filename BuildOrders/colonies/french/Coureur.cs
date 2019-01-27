using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Coureur : Villager
    {
        public Coureur() { }

        public override void SetAllowedBuildings()
        {
            allowedBuildings.AddRange(new List<ConstBuilding>
            {
                //Economic
                cBuilding.House,
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
