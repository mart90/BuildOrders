using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class IroquoisColonyBuilder : NativeColonyBuilder
    {
        public IroquoisColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Iroquois(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public IroquoisColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.Vills3,
                cShipment.Vills5,
                cShipment.Crates600w,
                cShipment.KanyaHorseman4,
            });
        }
    }
}
