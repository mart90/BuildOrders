using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class GermanColonyBuilder : EuropeanColonyBuilder
    {
        public GermanColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Germans(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public GermanColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.SettlerWagon2,
                cShipment.SettlerWagon3,
                cShipment.Crates700c,
                cShipment.Crates1000w,
            });
        }

        public override bool SendShipment()
        {
            shipmentsToSend[0] = shipmentsToSend[0].DeepCopy();
            if (colony.age > 1
                && !Germans.ShipmentComesWithUhlans(shipmentsToSend[0].name))
            {
                shipmentsToSend[0].populationcost += 2 * colony.age;
            }
            return base.SendShipment();
        }

        public override bool VillagerMakeBuilding(ConstBuilding building, int numvills = 1)
        {
            building = building.DeepCopy();
            building.buildtime = Convert.ToInt32(building.buildtime * .4);

            if (base.VillagerMakeBuilding(building))
            {
                base.VillagerMakeBuilding(new ConstBuilding("Dummy", 0, 0, 0, building.buildtime, 0, 0));
                return true;
            }

            return false;
        }
    }
}
