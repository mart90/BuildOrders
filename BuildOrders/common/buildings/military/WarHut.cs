using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public abstract class WarHut : UnitBuilding
    {
        public WarHut()
        {
            commonName = "WarHut";
        }
    }
}
