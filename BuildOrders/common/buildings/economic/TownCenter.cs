using System;

namespace BuildOrders
{
    [Serializable]
    public abstract class TownCenter : UnitBuilding
    {
        public TownCenter()
        {
            commonName = "TownCenter";
            maxUnitsQueued = 1;
        }
    }
}