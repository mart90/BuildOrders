using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public abstract class EuropeanColonyBuilder : ColonyBuilder
    {
        public override bool MakeBuilding(ConstBuilding building, int numvills = 1)
        {
            if (building.name == "TradingPost" && ((EuropeanColony)colony).atp)
            {
                building = building.DeepCopy();
                building.woodcost = 120;
            }
            return base.MakeBuilding(building, numvills);
        }
    }
}
