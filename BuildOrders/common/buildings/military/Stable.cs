using System;

namespace BuildOrders
{
    [Serializable]
    public abstract class Stable : UnitBuilding
    {
        public Stable()
        {
            commonName = "Stable";
        }
    }
}
