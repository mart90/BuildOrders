using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class OttomanColonyBuilder : EuropeanColonyBuilder
    {
        public OttomanColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Ottomans(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public OttomanColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.Vills3,
                cShipment.Crates700w,
                cShipment.Crates700c,
                cShipment.Crates600c,
            });
        }

        public override void MakeVills()
        {
            var ottomanvill = cUnit.Villager.DeepCopy();
            ottomanvill.populationcost = 0;
            ottomanvill.foodcost = 0;
            ottomanvill.traintime = ((Ottomans)colony).villTrainTime;

            foreach (UnitBuilding tc in colony.FindBuildingsByUnit(cUnit.Villager))
                MakeUnit(ottomanvill);
        }
    }
}
