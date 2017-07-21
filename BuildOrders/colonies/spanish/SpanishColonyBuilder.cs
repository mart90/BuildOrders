using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class SpanishColonyBuilder : EuropeanColonyBuilder
    {
        public SpanishColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Spanish(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public SpanishColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.Vills3,
                cShipment.Crates700w,
                cShipment.Vills5,
                cShipment.Crates700c,
            });
        }
    }
}
