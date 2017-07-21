using System;

namespace BuildOrders
{
    [Serializable]
    public abstract class Castle : UnitBuilding
    {
        public Castle()
        {
            commonName = "Castle";
        }
    }
}
