using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public abstract class ColonyBuilder : IScriptable
    {
        public ColonyBuilder()
        {
            AddDefaultShipments();
        }

        public Colony colony;
        public List<ConstShipment> shipmentsToSend = new List<ConstShipment>();
        public List<string> commandHistory = new List<string>();

        public bool autoVills = true;
        public bool shipmentsReset;
        public bool godmode;

        public abstract void AddDefaultShipments();

        public object GetFieldValueByName(string name)
        {
            return GetType().GetField(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public).GetValue(this);
        }

        public virtual void Continue()
        {
            colony.time++;
            CommonActions();
            colony.Income();
            colony.UpdateQueues();
        }

        public void CommonActions()
        {
            colony.HandleIdles();
            MakeVills();
            SendShipment();
        }

        public virtual void MakeVills()
        {
            if (autoVills)
            {
                foreach (UnitBuilding tc in colony.FindBuildingsByUnit(cUnit.Villager))
                    MakeUnit(cUnit.Villager);
            }
        }

        public virtual bool SendShipment()
        {
            if (shipmentsToSend.Count == 0)
                return false;

            var shipment = shipmentsToSend[0];
            if (colony.HomeCity().busy
                || colony.shipmentsAvailable == 0
                || colony.allowedShipments.Find(ashipment => ashipment.name == shipment.name) == null
                || colony.age < shipment.ageavailable
                || (colony.population >= colony.populationCap && shipment.populationcost > 0)
                || !colony.PayResources(shipment.foodcost, shipment.woodcost, shipment.coincost))
                return false;

            colony.shipmentsAvailable--;
            colony.shipmentsSent.Add(shipmentsToSend[0]);
            colony.population += shipment.populationcost;
            shipmentsToSend.RemoveAt(0);
            colony.HomeCity().MakeShipment(shipment);
            colony.queuesToUpdate.Add(colony.HomeCity());
            if (!shipment.infinite)
                colony.allowedShipments.Remove(shipment);
            return true;
        }

        public virtual bool MakeUnit(ConstUnit unit)
        {
            var building = GetMinQueueBuilding(unit);
            if (building == null
                || colony.population + unit.populationcost >= colony.populationCap
                || colony.age < unit.ageavailable)
                return false;

            if (building.unitQueued == unit
                && building.unitsQueued < building.maxUnitsQueued)
            {
                if (colony.PayResources(unit.foodcost, unit.woodcost, unit.coincost))
                {
                    colony.population += unit.populationcost;
                    building.unitsQueued++;
                    return true;
                }
            }
            else if (!building.busy)
            {
                if (colony.PayResources(unit.foodcost, unit.woodcost, unit.coincost))
                {
                    colony.population += unit.populationcost;
                    building.MakeUnit(unit);
                    colony.queuesToUpdate.Add(building);
                    return true;
                }
            }
            return false;
        }

        public UnitBuilding GetMinQueueBuilding(ConstUnit unit)
        {
            int minunitsqueued = 0;
            bool firstbuilding = true;
            UnitBuilding minqueuebuilding = null;
            foreach (UnitBuilding building in colony.FindBuildingsByUnit(unit))
            {
                if (firstbuilding)
                {
                    minunitsqueued = building.unitsQueued;
                    firstbuilding = false;
                }
                if (building.unitsQueued > 0
                    && building.unitQueued == unit
                    && building.unitsQueued <= minunitsqueued)
                {
                    minunitsqueued = building.unitsQueued;
                    minqueuebuilding = building;
                }
                else if (building.unitsQueued == 0)
                {
                    minqueuebuilding = building;
                }
            }
            return minqueuebuilding;
        }

        public bool ExplorerMakeBuilding(ConstBuilding building)
        {
            foreach (Explorer explorer in colony.explorers)
            {
                if (explorer.constructing)
                    continue;
                if (!colony.PayResources(building.foodcost, building.woodcost, building.coincost))
                    break;
                explorer.MakeBuilding(building);
                colony.constructionToUpdate.Add(explorer);
                return true;
            }
            return false;
        }

        public virtual bool VillagerMakeBuilding(ConstBuilding building, int numvills = 1)
        {
            var vill = colony.GetVillager();
            
            if (vill == null)
                return false;

            if (numvills > 1)
            {
                building = building.DeepCopy();
                building.buildtime = Convert.ToInt32(building.buildtime * Math.Pow(.8, numvills - 1));
            }

            if (vill.allowedBuildings.Find(abuilding => abuilding.name == building.name) != null
                && colony.PayResources(building.foodcost, building.woodcost, building.coincost))
            {
                vill.MakeBuilding(building);
                colony.constructionToUpdate.Add(vill);
                if (numvills > 1)
                {
                    for (int i = 1; i < numvills; i++)
                        colony.GetVillager().MakeBuilding(new ConstBuilding("Dummy", 0, 0, 0, building.buildtime, 0, 0));
                }
                return true;
            }
            return false;
        }
        
        public virtual bool MakeBuilding(ConstBuilding building, int numvills = 1)
        {
            if (colony.age < building.ageavailable)
                return false;

            if (colony.explorers[0].allowedBuildings.Find(abuilding => abuilding.name == building.name) != null)
                return ExplorerMakeBuilding(building);

            return VillagerMakeBuilding(building, numvills);
        }

        public virtual bool MakeTech(ConstTech tech)
        {
            if (colony.age < tech.ageavailable || colony.TechAlreadyQueued(tech))
                return false;

            foreach (Building building in colony.FindBuildingsByTech(tech))
            {
                if (building.busy)
                    continue;

                if (!colony.PayResources(tech.foodcost, tech.woodcost, tech.coincost))
                    return false;

                building.MakeTech(tech);
                colony.queuesToUpdate.Add(building);
                return true;
            }
            return false;
        }

        public void ShowTimeAndScore()
        {
            var time = colony.Time();
            var score = colony.Score().ToString();
            Console.Write(" ");
            for (int i = 0; i < time.Length + 2; i++)
                Console.Write("-");
            Console.Write(" ");
            for (int i = 0; i < score.Length + 2; i++)
                Console.Write("-");
            Console.WriteLine(" \n| " + time + " | " + score + " |\n");
        }

        public void ShowAll()
        {
            ShowTimeAndScore();
            ShowEco();
            ShowQueue();
            ShowBuildings();
            ShowMilitary();
        }

        public void QuickShow()
        {
            ShowTimeAndScore();
            Console.Write(" ");
            for (int i = 0; i < ((int)colony.food).ToString().Length + ((int)colony.wood).ToString().Length + ((int)colony.coin).ToString().Length + 8; i++)
                Console.Write("-");
            Console.WriteLine("\n| " + (int)colony.food + " | " + (int)colony.wood + " | " + (int)colony.coin + " |\n");

            ShowQueue();
        }

        public void ShowEco()
        {
            Console.WriteLine("Food\t" + (int)colony.food);
            Console.WriteLine("Wood\t" + (int)colony.wood);
            Console.WriteLine("Coin\t" + (int)colony.coin);
            Console.WriteLine("XP\t" + Convert.ToInt32(colony.xp) + "/" + colony.XPtonextShipment());
            if (this is AsianColonyBuilder)
                Console.WriteLine("Export\t" + (int)((AsianColony)colony).export);
            Console.WriteLine("\nVills\t" + colony.villagers.Count);
            Console.WriteLine("Food v\t" + colony.FoodGatherers().Count);
            Console.WriteLine("Wood v\t" + colony.WoodGatherers().Count);
            Console.WriteLine("Coin v\t" + colony.CoinGatherers().Count);
            Console.WriteLine("Pop\t" + colony.population + "/" + colony.populationCap);
            Console.WriteLine("Age\t" + colony.age + "\n");
            if (colony.buildingsGathering != Resource.Default)
                Console.WriteLine("Buildings gathering " + colony.buildingsGathering + "\n");
        }

        public void ShowQueue()
        {
            Console.WriteLine("--------------\nTimer\tQueued\n--------------");
            foreach (IBuilder builder in colony.constructionToUpdate)
            {
                if (builder.buildingQueued.name != "Dummy")
                    Console.WriteLine(builder.timer + "\t" + builder.buildingQueued.name);
            }
            foreach (Building building in colony.queuesToUpdate)
            {
                if (building.techQueued != null)
                {
                    Console.WriteLine(building.timer + "\t" + building.techQueued.name);
                }
                else if (building is HomeCity)
                {
                    Console.WriteLine(building.timer + "\t" + ((HomeCity)building).shipmentQueued.name);
                }
            }
            foreach (UnitBuilding building in colony.unitBuildings.FindAll(building => building.unitQueued != null))
            {
                if (building.unitsQueued > 1)
                    Console.WriteLine(building.timer + "\t" + building.unitsQueued + " " + building.unitQueued.name);
                else
                    Console.WriteLine(building.timer + "\t" + building.unitQueued.name);

            }
            Console.WriteLine();
        }

        public void ShowShipments()
        {
            Console.WriteLine("Shipments:\n----------");
            foreach (ConstShipment shipment in colony.shipmentsSent)
            {
                Console.WriteLine(shipment.name + " (sent)");
            }
            foreach (ConstShipment shipment in shipmentsToSend)
            {
                Console.WriteLine(shipment.name);
            }
        }

        public virtual void ShowMilitary()
        {
            Console.WriteLine("Military:\n---------");
            foreach (ConstUnit militaryunit in colony.militaryUnits.GroupBy(unit => unit.name).Select(group => group.First()))
            {
                Console.WriteLine(colony.militaryUnits.FindAll(unit => unit.name == militaryunit.name).Count + " " + militaryunit.name);
            }
            Console.WriteLine();
        }

        public virtual void ShowBuildings()
        {
            Console.WriteLine("Buildings:\n----------");
            foreach (Building building in colony.AllBuildings().GroupBy(building => building.commonName).Select(group => group.First()))
            {
                if (!(building is HomeCity))
                {
                    Console.WriteLine(colony.AllBuildings().FindAll(bldg => bldg.commonName == building.commonName).Count + " " + building.commonName);
                }
            }
            Console.WriteLine();
        }
    }
}