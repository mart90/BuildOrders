using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class PortugueseColonyBuilder : EuropeanColonyBuilder
    {
        public PortugueseColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Portuguese(randomcrate, tpstart);
            colony.time = colony.startTime;
        }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.Crates300w,
                cShipment.Crates700c,
                cShipment.Crates600c,
                cShipment.Crates1000w,
            });
        }

        public override bool MakeUnit(ConstUnit unit)
        {
            if (unit.name == "Villager")
            {
                unit = unit.DeepCopy();
                unit.foodcost = 85;
            }
            return base.MakeUnit(unit);
        }
    }
}
