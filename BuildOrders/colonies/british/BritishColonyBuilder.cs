using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class BritishColonyBuilder : EuropeanColonyBuilder
    {
        public BritishColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new British(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public BritishColonyBuilder() { }

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
            if (building.name == "Manor")
            {
                if (((British)colony).manorcount == 20)
                    return false;

                if (((British)colony).virginiaCompany)
                    building = cBuilding.ManorWithVC;

                if (base.MakeBuilding(building, numvills))
                {
                    ((British)colony).manorcount++;
                    return true;
                }
                return false;
            }
            else
                return base.MakeBuilding(building, numvills);
        }
    }
}
