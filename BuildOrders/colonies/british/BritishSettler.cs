using System;

namespace BuildOrders
{
    [Serializable]
    public class BritishSettler : Villager
    {
        public BritishSettler() { }

        public override void SetAllowedBuildings()
        {
            ConstBuilding[] allowedbuildings =
            {
                //Economic
                cBuilding.Manor,
                cBuilding.TradingPost,
                cBuilding.Market,
                cBuilding.Dock,
                
                //Military
                cBuilding.Barracks,
                cBuilding.Stable,
                cBuilding.ArtilleryFoundry,
            };

            allowedBuildings.AddRange(allowedbuildings);
        }
    }
}