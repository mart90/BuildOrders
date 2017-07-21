using System;

namespace BuildOrders
{
    [Serializable]
    public abstract class Barracks : UnitBuilding
    {
        public Barracks()
        {
            commonName = "Barracks";
        }
    }
}
