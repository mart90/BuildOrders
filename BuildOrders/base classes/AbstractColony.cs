using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace BuildOrders
{
    [Serializable]
    public abstract class Colony : IScriptable
    {
        //Logger
        public List<string> logger = new List<string>();
        public void Log(string message)
        {
            string time = Time();
            if (time.Length < 5)
                time = time.Insert(0, "0");

            logger.Add(DateTime.Now + " | " + time + " | " + message);
        }

        //General
        public int time;
        public string Time()
        {
            int minutes = time / 60;
            int seconds = time % 60;
            if (seconds < 10)
                return minutes + ":0" + seconds;
            else
                return minutes + ":" + seconds;
        }
        public HomeCity HomeCity()
        {
            return (HomeCity)techBuildings.Find(building => building.GetType() == typeof(HomeCity));
        }
        public List<Explorer> explorers = new List<Explorer>();
        public int age = 1;
        public Resource newVillstoResource = Resource.Food;
        public Resource newBoatstoResource = Resource.Food;
        public Resource randomCrate;
        public int startTime;
        public int population;
        public int populationCap;
        public int techScore;
        public int buildingScore;

        //Income
        public int foodCrateSeconds;
        public int woodCrateSeconds;
        public int coinCrateSeconds;

        public List<Villager> FoodGatherers()
        {
            return villagers.FindAll(vill => vill.resourceGathering == Resource.Food);
        }

        public List<Villager> WoodGatherers()
        {
            return villagers.FindAll(vill => vill.resourceGathering == Resource.Wood);
        }

        public List<Villager> CoinGatherers()
        {
            return villagers.FindAll(vill => vill.resourceGathering == Resource.Coin);
        }

        public List<FishingBoat> FishGatherers()
        {
            return fishingBoats.FindAll(boat => boat.resourceGathering == Resource.Food);
        }

        public List<FishingBoat> WhaleGatherers()
        {
            return fishingBoats.FindAll(boat => boat.resourceGathering == Resource.Coin);
        }

        public double foodBaseGatherRate = .84;
        public double woodBaseGatherRate = .5;
        public double coinBaseGatherRate = .6;
        public double fishBaseGatherRate = .67;
        public double whaleBaseGatherRate = .5;

        public decimal foodGatherRateBonus = 1.0m;
        public decimal woodGatherRateBonus = 1.0m;
        public decimal coinGatherRateBonus = 1.0m;
        public decimal fishGatherRateBonus = 1.0m;
        public decimal whaleGatherRateBonus = 1.0m;

        public bool stageCoach;
        public Resource buildingsGathering = Resource.Default;

        //Queue
        public List<Building> queuesToUpdate = new List<Building>();
        public List<IBuilder> constructionToUpdate = new List<IBuilder>();

        //Resources
        public double food;
        public double wood;
        public double coin;
        public double xp;

        //Units
        public List<Villager> villagers = new List<Villager>();
        public List<FishingBoat> fishingBoats = new List<FishingBoat>();
        public List<ConstUnit> militaryUnits = new List<ConstUnit>();

        //Buildings
        public List<Building> AllBuildings()
        {
            return techBuildings.Concat(unitBuildings).ToList();
        }

        public List<Building> techBuildings = new List<Building>();
        public List<UnitBuilding> unitBuildings = new List<UnitBuilding>();

        //Shipments
        public List<ConstShipment> allowedShipments = new List<ConstShipment>();
        public int shipmentsAvailable;
        public List<ConstShipment> shipmentsSent = new List<ConstShipment>();

        public bool advancedDock;
        public bool schooners;
        
        //Add units
        public abstract void AddVillager(int amount = 1);

        public void AddFishingBoat(int amount = 1)
        {
            for (var i = 0; i < amount; i++)
            {
                fishingBoats.Add(new FishingBoat());
            }
        }

        //Add buildings
        public abstract void AddMarket();
        public abstract void AddTownCenter();

        public void AddTradingPost()
        {
            techBuildings.Add(new TradingPost());
        }

        public virtual void AddHouse()
        {
            populationCap += 10;
            xp += cBuilding.House.buildxp;
        }

        //Add techs
        public void AddStageCoach()
        {
            stageCoach = true;
        }

        //Add shipments
        public void AddVills3()
        {
            AddVillager(3);
        }

        public virtual void AddCrates300w()
        {
            woodCrateSeconds += 30;
        }

        public void AddVills5()
        {
            AddVillager(5);
        }

        public void AddVills4()
        {
            AddVillager(4);
        }

        public void AddSpiceTrade()
        {
            foodGatherRateBonus += .2m;
        }

        public virtual void AddCrates700w()
        {
            woodCrateSeconds += 70;
        }

        public virtual void AddCrates600w()
        {
            woodCrateSeconds += 60;
        }

        public virtual void AddCrates700c()
        {
            coinCrateSeconds += 70;
        }

        public virtual void AddCrates600c()
        {
            coinCrateSeconds += 60;
        }

        public virtual void AddCrates700f()
        {
            foodCrateSeconds += 70;
        }

        public virtual void AddCrates600f()
        {
            foodCrateSeconds += 60;
        }

        public void AddCrates1000f()
        {
            foodCrateSeconds += 100;
        }

        public virtual void AddCrates1000w()
        {
            woodCrateSeconds += 100;
        }

        public virtual void AddCrates1000c()
        {
            coinCrateSeconds += 100;
        }

        public void AddCrates1600f()
        {
            foodCrateSeconds += 160;
        }

        public void AddCrates1600w()
        {
            woodCrateSeconds += 160;
        }

        public void AddCrates1600c()
        {
            coinCrateSeconds += 160;
        }

        public void AddManchu9()
        {
            AddUnits(cUnit.Manchu, 9);
        }

        public void AddSwissPikeman12()
        {
            AddUnits(cUnit.SwissPikeman, 12);
        }

        public void AddJaeger13()
        {
            AddUnits(cUnit.Jaeger, 13);
        }

        public void AddJaeger10()
        {
            AddUnits(cUnit.Jaeger, 10);
        }

        public void AddHighlander9()
        {
            AddUnits(cUnit.Highlander, 9);
        }

        public void AddBlackRider9()
        {
            AddUnits(cUnit.BlackRider, 9);
        }

        public void AddBlackRider7()
        {
            AddUnits(cUnit.BlackRider, 7);
        }

        public void AddMameluke4()
        {
            AddUnits(cUnit.Mameluke, 4);
        }

        public void AddSchooners()
        {
            schooners = true;
        }

        public void AddAdvancedDock()
        {
            advancedDock = true;
        }

        public void AddRenderingPlant()
        {
            fishGatherRateBonus += .3m;
            whaleGatherRateBonus += .3m;
        }


        public List<Building> FindBuildingsByTech(ConstTech tech)
        {
            return AllBuildings().FindAll(building => building.allowedTechs.Find(atech => atech.name == tech.name) != null);
        }

        public List<UnitBuilding> FindBuildingsByUnit(ConstUnit unit)
        {
            return unitBuildings.FindAll(building => building.allowedUnits.Find(aunit => aunit.name == unit.name) != null);
        }

        public List<ConstUnit> FindUnitsByName(string name)
        {
            return militaryUnits.FindAll(unit => unit.name.ToLower() == name);
        }

        public List<Building> FindBuildingsByName(string name)
        {
            return AllBuildings().FindAll(building => building.commonName.ToLower() == name);
        }

        public object GetFieldValueByName(string name)
        {
            return GetType().GetField(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public).GetValue(this);
        }

        public virtual int GetCountByUnitName(string name)
        {
            if (name == "villager")
                return villagers.Count;
            if (name == "fishingboat")
                return fishingBoats.Count;

            return FindUnitsByName(name).Count;
        }

        public virtual int GetCountByBuildingName(string name)
        {
            if (name == "house")
                return (int)(.1 * populationCap) - FindBuildingsByName("TownCenter").Count;

            return FindBuildingsByName(name).Count;
        }

        public abstract void SetAllowedShipments();
        public abstract int FoodStart();
        public abstract int WoodStart(bool tpstart = false);
        public abstract int CoinStart();

        public virtual void Income()
        {
            Gather();
            GatherCrates();
            xp += 2;
            GatherFromTPs();
            CheckShipment();
        }

        public void RemoveAllowedTech(ConstTech tech)
        {
            foreach (Building building in FindBuildingsByTech(tech))
                building.allowedTechs.Remove(tech);
        }

        public void AddAllowedTech(ConstTech techtosearch, ConstTech newtech)
        {
            foreach (Building building in FindBuildingsByTech(techtosearch))
                building.allowedTechs.Add(newtech);
        }

        public bool TechAlreadyQueued(ConstTech tech)
        {
            return techBuildings.Find(abuilding => abuilding.techQueued != null && abuilding.techQueued.name == tech.name) != null;
        }

        public virtual void Gather()
        {
            food += foodBaseGatherRate * (double)foodGatherRateBonus * FoodGatherers().Count;
            wood += woodBaseGatherRate * (double)woodGatherRateBonus * WoodGatherers().Count;
            coin += coinBaseGatherRate * (double)coinGatherRateBonus * CoinGatherers().Count;

            food += fishBaseGatherRate * (double)fishGatherRateBonus * FishGatherers().Count;
            coin += whaleBaseGatherRate * (double)whaleGatherRateBonus * WhaleGatherers().Count;
        }

        public virtual void GatherFromTPs()
        {
            int tps = techBuildings.FindAll(building => building.GetType() == typeof(TradingPost)).Count;
            if (stageCoach)
            {
                if (buildingsGathering == Resource.Default)
                    xp += tps * 2;
                else if (buildingsGathering == Resource.Food)
                    food += tps * 2;
                else if (buildingsGathering == Resource.Wood)
                    wood += tps * 2;
                else if (buildingsGathering == Resource.Coin)
                    coin += tps * 2;
            }
            else
                xp += tps * 1.1;
        }

        public void LoseResForCrateGathering()
        {
            if (FoodGatherers().Count >= Math.Max(WoodGatherers().Count, CoinGatherers().Count))
            {
                food -= foodBaseGatherRate * (double)foodGatherRateBonus;
            }
            else if (WoodGatherers().Count >= CoinGatherers().Count)
            {
                wood -= woodBaseGatherRate * (double)woodGatherRateBonus;
            }
            else
            {
                coin -= coinBaseGatherRate * (double)coinGatherRateBonus;
            }
        }

        public void GatherCrates()
        {
            if (foodCrateSeconds > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (foodCrateSeconds == 0)
                        break;
                    LoseResForCrateGathering();
                    foodCrateSeconds--;
                    food += 10;
                }
            }
            if (woodCrateSeconds > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (woodCrateSeconds == 0)
                        break;
                    LoseResForCrateGathering();
                    woodCrateSeconds--;
                    wood += 10;
                }
            }
            if (coinCrateSeconds > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (coinCrateSeconds == 0)
                        break;
                    LoseResForCrateGathering();
                    coinCrateSeconds--;
                    coin += 10;
                }
            }
        }

        public void CheckShipment()
        {
            int xptonextshipment = XPtonextShipment();
            if (xp >= xptonextshipment)
            {
                shipmentsAvailable++;
                xp -= xptonextshipment;
            }
        }

        public virtual int XPtonextShipment()
        {
            int shipments = shipmentsAvailable + shipmentsSent.Count;
            switch (shipments)
            {
                case 0: return 300;
                case 1: return 345;
                case 2: return 397;
                case 3: return 456;
                case 4: return 525;
                case 5: return 603;
                case 6: return 694;
                case 7: return 798;
                case 8: return 918;
                case 9: return 1055;
                case 10: return 1214;

                default: return 1214;
            }
        }

        public virtual Villager GetVillager()
        {
            if (FoodGatherers().Count + WoodGatherers().Count + CoinGatherers().Count == 0)
                return null;

            if (FoodGatherers().Count >= Math.Max(WoodGatherers().Count, CoinGatherers().Count))
                return FoodGatherers()[0];
            else if (WoodGatherers().Count > CoinGatherers().Count)
                return WoodGatherers()[0];
            else
                return CoinGatherers()[0];
        }

        public void HandleIdles()
        {
            IdleVillsToResource(newVillstoResource);
            IdleFishingBoatsToResource(newBoatstoResource);
        }

        public bool SwitchVills(Resource fromResource, Resource toResource, int amount)
        {
            if (VillsFromResource(fromResource, amount))
            {
                IdleVillsToResource(toResource);
                Log("Switched " + amount + " villagers from " + fromResource + " to " + toResource);
                return true;
            }
            return false;
        }

        public virtual void MakeBuildingFromWagon(ConstBuilding building, int buildtime)
        {
            constructionToUpdate.Add(new WagonBuilder(building, buildtime));
        }

        public bool VillsFromResource(Resource resource, int amount)
        {
            var vills = villagers.FindAll(vill => vill.resourceGathering == resource);
            if (vills.Count < amount)
                amount = vills.Count;

            int i = 0;
            foreach (Villager vill in vills)
            {
                i++;
                vill.StopGathering();
                if (i == amount)
                    return true;
            }
            return false;
        }

        public List<Villager> IdleVillagers()
        {
            return villagers.FindAll(vill => vill.idle);
        }

        public List<FishingBoat> IdleFishingBoats()
        {
            return fishingBoats.FindAll(boat => boat.idle);
        }

        public void IdleVillsToResource(Resource resource)
        {
            foreach (Villager vill in IdleVillagers())
                vill.GatherResource(resource);
        }

        public void IdleFishingBoatsToResource(Resource resource)
        {
            foreach (FishingBoat boat in IdleFishingBoats())
                boat.GatherResource(resource);
        }

        public void AllocateVills(int food, int wood, int coin)
        {
            List<Villager> villstoallocate = new List<Villager>();
            villstoallocate.AddRange(Gatherers());
            villstoallocate.AddRange(IdleVillagers());
            foreach (Villager vill in villstoallocate)
            {
                vill.StopGathering();
            }

            double total = food + wood + coin;
            double villstofood = villstoallocate.Count * (food / total);
            double villstowood = villstoallocate.Count * (wood / total);
            double villstocoin = villstoallocate.Count * (coin / total);
            for (int i = 0; i < (int)villstofood; i++)
            {
                villstoallocate[0].GatherResource(Resource.Food);
                villstoallocate.RemoveAt(0);
            }
            for (int i = 0; i < (int)villstowood; i++)
            {
                villstoallocate[0].GatherResource(Resource.Wood);
                villstoallocate.RemoveAt(0);
            }
            for (int i = 0; i < (int)villstocoin; i++)
            {
                villstoallocate[0].GatherResource(Resource.Coin);
                villstoallocate.RemoveAt(0);
            }
            foreach (Villager vill in villstoallocate)
            {
                vill.GatherResource(newVillstoResource);
            }
            Log("Allocated " + FoodGatherers().Count + " vills to food, " + WoodGatherers().Count + " to wood, " + CoinGatherers().Count + " to coin");
        }

        public void AllocateBoats(int food, int coin)
        {
            foreach (FishingBoat boat in fishingBoats)
            {
                boat.StopGathering();
            }

            double total = food + coin;
            double boatstofood = fishingBoats.Count * (food / total);
            double boatstocoin = fishingBoats.Count * (coin / total);

            for (int i = 0; i < (int)boatstofood; i++)
            {
                fishingBoats[0].GatherResource(Resource.Food);
                fishingBoats.RemoveAt(0);
            }
            for (int i = 0; i < (int)boatstocoin; i++)
            {
                fishingBoats[0].GatherResource(Resource.Coin);
                fishingBoats.RemoveAt(0);
            }
            foreach (FishingBoat boat in fishingBoats)
            {
                boat.GatherResource(newBoatstoResource);
            }
            Log("Allocated " + FishGatherers().Count + " fishing boats to food, " + WhaleGatherers().Count + " to coin");
        }

        public List<Villager> Gatherers()
        {
            return villagers.FindAll(vill => vill.resourceGathering != Resource.Default);
        }

        public virtual void UpdateQueues()
        {
            foreach (Building building in queuesToUpdate)
                building.timer--;

            foreach (IBuilder builder in constructionToUpdate)
                builder.timer--;

            ResolveFinishedBuildingQueues();
            ResolveFinishedConstruction();
        }

        public void ResolveFinishedBuildingQueues()
        {
            var finishedqueues = new List<Building>();

            foreach (Building building in queuesToUpdate)
            {
                if (!building.QueueFinished())
                    continue;

                finishedqueues.Add(building);

                if (building.techQueued != null)
                    AddTech(building.techQueued);
                else if (building.GetType() == typeof(HomeCity))
                    AddShipment(((HomeCity)building).shipmentQueued);
                else
                {
                    var unitqueued = ((UnitBuilding)building).unitQueued;
                    var amountqueued = ((UnitBuilding)building).unitsQueued;
                    AddUnits(unitqueued, amountqueued);
                    xp += unitqueued.buildxp * amountqueued;
                }
                building.ClearQueue();
            }

            foreach (Building building in finishedqueues)
                queuesToUpdate.Remove(building);
        }

        public void ResolveFinishedConstruction()
        {
            var finishedconstruction = new List<IBuilder>();

            foreach (IBuilder builder in constructionToUpdate)
            {
                if (!builder.ConstructionFinished())
                    continue;

                finishedconstruction.Add(builder);

                AddBuilding(builder.buildingQueued);
                builder.ClearQueue();
            }

            foreach (IBuilder builder in finishedconstruction)
                constructionToUpdate.Remove(builder);
        }

        public bool PayResources(int food, int wood = 0, int coin = 0)
        {
            if (Convert.ToInt32(this.food) < food
                || Convert.ToInt32(this.wood) < wood
                || Convert.ToInt32(this.coin) < coin)
                return false;

            this.food -= food;
            this.wood -= wood;
            this.coin -= coin;
            return true;
        }

        public int Score()
        {
            return (int)(.01 * (UnitScore() + buildingScore + UnspentScore() + techScore) + explorers.Count);
        }

        public virtual int UnitScore()
        {
            var score = 0;
            score += villagers.Count * 100;
            foreach (ConstUnit unit in militaryUnits)
            {
                score += unit.foodcost + unit.coincost + unit.woodcost + unit.exportcost;
            }
            return score;
        }

        public virtual double UnspentScore()
        {
            return food + coin + wood;
        }

        public int Setup(bool tpstart = false)
        {
            AddTownCenter();
            buildingScore += 600;
            if (randomCrate == Resource.Food)
                return FoodStart();
            else if (randomCrate == Resource.Wood)
                return WoodStart(tpstart);
            else
                return CoinStart();
        }

        public virtual void AddUnits(ConstUnit unit, int amount)
        {
            if (unit.name == "Villager")
                AddVillager(amount);
            else if (unit.name == "FishingBoat")
                AddFishingBoat(amount);
            else
            {
                for (int i = 0; i < amount; i++)
                    militaryUnits.Add(unit);
            }
            if (amount > 1)
                Log("Trained " + unit.name + " batch. Amount: " + amount);
            else
                Log("Trained " + unit.name);
        }

        public virtual void AddTech(ConstTech tech)
        {
            string addMethod = "Add" + tech.name;
            MethodInfo method = GetType().GetMethod(addMethod);
            method.Invoke(this, null);

            RemoveAllowedTech(tech);

            techScore += tech.foodcost + tech.woodcost + tech.coincost;
            Log("Researched " + tech.name);
        }

        public virtual void AddBuilding(ConstBuilding building)
        {
            if (building.name == "Dummy")
                return;

            string addMethod = "Add" + building.name;
            MethodInfo method = GetType().GetMethod(addMethod);
            method.Invoke(this, null);

            xp += building.buildxp;
            buildingScore += building.foodcost + building.woodcost + building.coincost;
            Log("Built " + building.name);
        }

        public virtual void AddShipment(ConstShipment shipment)
        {
            string addMethod = "Add" + shipment.name;
            MethodInfo method = GetType().GetMethod(addMethod);
            method.Invoke(this, null);

            Log("Shipment " + shipment.name + " arrived");
        }
    }
}
