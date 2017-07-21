using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class SiouxColonyBuilder : NativeColonyBuilder
    {
        public SiouxColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Sioux(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public SiouxColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.Vills3,
                cShipment.Vills4,
                cShipment.AxeRider4,
                cShipment.Crates700c,
            });
        }
    }
}
