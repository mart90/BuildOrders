using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class IndiansColonyBuilder : AsianColonyBuilder
    {
        public IndiansColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Indians(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public IndiansColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            { 
                cShipment.Distributivism,
                cShipment.Crates600w,
                cShipment.Export300,
                cShipment.Crates600c,
            });
        }

        public override bool MakeBuilding(ConstBuilding building, int numvills = 1)
        {
            if (building.name == "House")
                building = cBuilding.IndianHouse;

            return base.MakeBuilding(building, numvills);
        }

        public override bool MakeUnit(ConstUnit unit)
        {
            if (unit == cUnit.Villager)
                unit = cUnit.IndianVillager;
            return base.MakeUnit(unit);
        }
    }
}
