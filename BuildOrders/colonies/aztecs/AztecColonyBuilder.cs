using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class AztecColonyBuilder : NativeColonyBuilder
    {
        public AztecColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Aztecs(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public AztecColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.Vills3,
                cShipment.Crates700w,
                cShipment.WarriorPriest3,
                cShipment.Crates600w,
            });
        }
    }
}
