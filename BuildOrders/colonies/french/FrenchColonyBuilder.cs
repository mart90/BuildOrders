using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class FrenchColonyBuilder : EuropeanColonyBuilder
    {
        public FrenchColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new French(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public FrenchColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.Vills3,
                cShipment.Vills4,
                cShipment.Crates700c,
                cShipment.Crates700w,
            });
        }

        public override bool MakeUnit(ConstUnit unit)
        {
            if (unit == cUnit.Villager)
                unit = cUnit.Coureur;
            return base.MakeUnit(unit);
        }
    }
}
