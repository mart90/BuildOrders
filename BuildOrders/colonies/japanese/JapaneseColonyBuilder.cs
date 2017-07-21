using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class JapaneseColonyBuilder : AsianColonyBuilder
    {
        public JapaneseColonyBuilder(Resource randomcrate, bool tpstart)
        {
            colony = new Japanese(randomcrate, tpstart);
            colony.time = colony.startTime;
        }
        public JapaneseColonyBuilder() { }

        public List<ConstShipment> resendableShipmentsSent = new List<ConstShipment>();

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.HeavenlyKami,
                cShipment.Crates600w,
                cShipment.Crates600w,
                cShipment.Vills4,
            });
        }

        public override bool SendShipment()
        {
            if (shipmentsToSend.Count == 0)
                return false;

            var shipment = shipmentsToSend[0];
            if (colony.HomeCity().busy
                || colony.shipmentsAvailable == 0
                || colony.allowedShipments.Find(ashipment => ashipment.name == shipment.name) == null
                || colony.age < shipment.ageavailable
                || colony.population >= colony.populationCap
                || !colony.PayResources(shipment.foodcost, shipment.woodcost, shipment.coincost))
                return false;

            colony.shipmentsAvailable--;
            colony.shipmentsSent.Add(shipmentsToSend[0]);
            colony.population += shipment.populationcost;
            shipmentsToSend.RemoveAt(0);
            colony.HomeCity().MakeShipment(shipment);
            colony.queuesToUpdate.Add(colony.HomeCity());

            if (shipment.infinite)
                return true;
            if (Resendable(shipment))
                resendableShipmentsSent.Add(shipment);
            else
                colony.allowedShipments.Remove(shipment);
            return true;
        }

        public bool Resendable(ConstShipment shipment)
        {
            return shipment.resendable && resendableShipmentsSent.Find(shpmnt => shpmnt.name == shipment.name) == null;
        }

        public override bool MakeBuilding(ConstBuilding building, int numvills = 1)
        {
            building = building.DeepCopy();
            if (((Japanese)colony).MyConsulate().alliance == Alliance.Portuguese)
            {
                building.woodcost = Convert.ToInt32(building.woodcost * .85);
                building.foodcost = Convert.ToInt32(building.foodcost * .85);
            }

            if (building.name == "Shrine" && ((Japanese)colony).heavenlyKami)
                building.woodcost -= 18;
            
            if (((Japanese)colony).militaryRicksjaws > 0 && (building.name == "Barracks" || building.name == "Stable"))
            {
                building.woodcost = 0;
                building.buildtime = 10;
                building.buildxp = 0;
                ((Japanese)colony).militaryRicksjaws--;
            }

            return base.MakeBuilding(building, numvills);
        }

        public override bool MakeUnit(ConstUnit unit)
        {
            var foodcost = unit.foodcost;
            var woodcost = unit.woodcost;
            var coincost = unit.coincost;

            if (((Japanese)colony).shogunate)
            {
                foodcost = (int)(unit.foodcost * .95);
                woodcost = (int)(unit.woodcost * .95);
                coincost = (int)(unit.coincost * .95);
            }

            var building = GetMinQueueBuilding(unit);
            if (building == null
                || colony.population + unit.populationcost >= colony.populationCap
                || colony.age < unit.ageavailable)
                return false;

            if (building.unitQueued == unit
                && building.unitsQueued < building.maxUnitsQueued)
            {
                if (colony.PayResources(foodcost, woodcost, coincost))
                {
                    colony.population += unit.populationcost;
                    building.unitsQueued++;
                    return true;
                }
            }
            else if (!building.busy)
            {
                if (colony.PayResources(foodcost, woodcost, coincost))
                {
                    colony.population += unit.populationcost;
                    building.MakeUnit(unit);
                    if (((Japanese)colony).shogunate)
                        building.timer = (int)(building.timer * .9);
                    colony.queuesToUpdate.Add(building);
                    return true;
                }
            }
            return false;
        }
    }
}
