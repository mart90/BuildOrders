using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildOrders
{
    [Serializable]
    public class ChineseColonyBuilder : ColonyBuilder
    {
        public ChineseColonyBuilder(bool tpstart)
        {
            colony = new Chinese(tpstart);
            colony.time = colony.startTime;
        }
        public ChineseColonyBuilder() { }

        public override void AddDefaultShipments()
        {
            shipmentsToSend.AddRange(new List<ConstShipment>
            {
                cShipment.NorthernRefugees,
                cShipment.Crates700c,
                cShipment.Crates700w,
                cShipment.MeteorHammer5,
            });
        }

        public override bool MakeUnit(ConstUnit unit)
        {
            if (((Chinese)colony).oldHanReforms)
            {
                if (unit.name == "OldHanArmy")
                    unit = cUnit.OldHanArmyReformed;
                if (unit.name == "StandardArmy")
                    unit = cUnit.StandardArmyReformed;
                if (unit.name == "MingArmy")
                    unit = cUnit.MingArmyReformed;
            }

            var foodcost = unit.foodcost;
            var woodcost = unit.woodcost;
            var coincost = unit.coincost;

            var building = GetMinQueueBuilding(unit);
            if (building == null
                || colony.population + unit.populationcost >= colony.populationCap
                || colony.age < unit.ageavailable)
                return false;

            if (((Chinese)colony).consulate.alliance == Alliance.Germans
                && building.GetType() == typeof(WarAcademy))
            {
                if (foodcost > 0)
                    foodcost = foodcost - 15;
                if (woodcost > 0)
                    woodcost = woodcost - 15;
                if (coincost > 0)
                    coincost = coincost - 15;
            }

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
                    if (((Chinese)colony).consulate.alliance == Alliance.Russians
                        && unit.name == "Villager")
                        building.timer = 22;
                    colony.queuesToUpdate.Add(building);
                    return true;
                }
            }
            return false;
        }

        public override void Continue()
        {
            base.Continue();
            WonderProduction();
        }

        public void WonderProduction()
        {
            var summerpalace = (SummerPalace)(colony.unitBuildings.Find(building => building.commonName == "SummerPalace"));
            if (summerpalace != null && !summerpalace.busy)
            {
                if (colony.age == 2)
                    summerpalace.MakeOldHanArmy();
                else
                    summerpalace.MakeForbiddenArmy();
                colony.queuesToUpdate.Add(summerpalace);
            }

            var confucianacademy = (ConfucianAcademy)(colony.unitBuildings.Find(building => building.commonName == "ConfucianAcademy"));
            if (confucianacademy != null && !confucianacademy.busy)
            {
                confucianacademy.MakeFlyingCrow();
                colony.queuesToUpdate.Add(confucianacademy);
            }
        }

        public override void ShowMilitary()
        {
            var col = (Chinese)colony;
            Console.WriteLine("Military:\n---------");

            var ckn     = col.ChuKoNuCount();
            var steppes = col.SteppeRiderCount();
            var pikes   = col.QiangPikemanCount();
            var keshik  = col.KeshikCount();
            var arqs    = col.ArquebusierCount();
            var changdao = col.ChangdaoSwordsmanCount();
            var meteors = col.MeteorHammerCount();
            var flails  = col.IronFlailCount();

            if (ckn > 0)
                Console.WriteLine(ckn + " ChuKoNu");
            if (steppes > 0)
                Console.WriteLine(steppes + " SteppeRider");
            if (pikes > 0)
                Console.WriteLine(pikes + " QiangPikeman");
            if (keshik > 0)
                Console.WriteLine(keshik + " Keshik");
            if (arqs > 0)
                Console.WriteLine(arqs + " Arquebusier");
            if (changdao > 0)
                Console.WriteLine(changdao + " ChangdaoSwordsman");
            if (meteors > 0)
                Console.WriteLine(meteors + " MeteorHammer");
            if (flails > 0)
                Console.WriteLine(flails + " IronFlail");

            var qry = 
                from unit in col.militaryUnits
                where unit.name != "ChuKoNu"
                    && unit.name != "SteppeRider"
                    && unit.name != "QiangPikeman"
                    && unit.name != "Keshik"
                    && unit.name != "Arquebusier"
                    && unit.name != "ChangdaoSwordsman"
                    && unit.name != "MeteorHammer"
                    && unit.name != "IronFlail"
                group unit by unit.name into units
                select units;
                      
            foreach (ConstUnit unit in qry)
            {
                Console.WriteLine(col.militaryUnits.FindAll(u => u.name == unit.name).Count + " " + unit.name);
            }

            Console.WriteLine();
        }
    }
}
