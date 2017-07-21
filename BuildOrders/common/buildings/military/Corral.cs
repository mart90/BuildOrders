using System;

namespace BuildOrders
{
    [Serializable]
    public abstract class Corral : UnitBuilding
    {
        public Corral()
        {
            commonName = "Corral";
        }
    }
}
