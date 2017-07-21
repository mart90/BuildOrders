using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class DutchColonyBuilder : EuropeanColonyBuilder
    {
        public DutchColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Dutch(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public DutchColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.Vills3,
                cShipment.Crates700w,
                cShipment.Crates600w,
                cShipment.Crates700c,
            });
        }

        public override bool MakeBuilding(ConstBuilding building, int numvills = 1)
        {
            if (building.name == "Bank" && ((Dutch)colony).bankCount >= ((Dutch)colony).bankLimit)
                return false;

            return base.MakeBuilding(building, numvills);
        }

        public override bool MakeUnit(ConstUnit unit)
        {
            if (unit == cUnit.Villager)
                unit = cUnit.DutchVillager;
            return base.MakeUnit(unit);
        }
    }
}
