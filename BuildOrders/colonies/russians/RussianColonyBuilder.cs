using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class RussianColonyBuilder : EuropeanColonyBuilder
    {
        public RussianColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Russians(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public RussianColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.EconomicTheory,
                cShipment.Cossack5,
                cShipment.Crates700w,
                cShipment.Crates700c,
            });
        }

        public override bool MakeUnit(ConstUnit unit)
        {
            if (unit == cUnit.Villager)
                unit = cUnit.VillagerBatch;
            return base.MakeUnit(unit);
        }
    }
}
