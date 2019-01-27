using System;

namespace BuildOrders
{
    [Serializable]
    public abstract class Dock : UnitBuilding
    {
        public Dock()
        {
            commonName = "Dock";
            maxUnitsQueued = 1;
        }
    }
}
