using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class British : EuropeanColony
    {
        //Crates: 2f 2w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public British(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
        }
        public British() { }

        public bool virginiaCompany = false;
        public int manorcount;

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.Vills3,
                cShipment.Crates300w,
                cShipment.VirginiaCompany,
                cShipment.EconomicTheory,

                //Colonial
                cShipment.Vills4,
                cShipment.Vills5,
                cShipment.Crates600c,
                cShipment.Crates600w,
                cShipment.Crates700c,
                cShipment.Crates700w,
                cShipment.Crates700f,
                cShipment.Crates600f,
                cShipment.SpiceTrade,

                cShipment.Longbowman6,
                cShipment.Musketeer6,

                //Fortress
                cShipment.Vills8,
                cShipment.Crates1000w,
                cShipment.Crates1000c,
                cShipment.Crates1000f,

                cShipment.Longbowman10,
                cShipment.Longbowman8,
                cShipment.Hussar5,
                cShipment.Hussar4,
                cShipment.Pikeman10,
                cShipment.Musketeer9,
                cShipment.Falconet2,
                cShipment.Jaeger10,
                cShipment.Highlander9,

                //Industrial
                cShipment.Factory,
                cShipment.RobberBarons,

                cShipment.Longbowman20,
                cShipment.Rocket3,
                cShipment.Rocket2,
            });
        }

        public override List<UnitBuilding> FindFactories()
        {
            return FindBuildingsByUnit(cUnit.Rocket);
        }

        public override void FactoriesMakeUnit(List<UnitBuilding> factories)
        {
            foreach (BritishFactory factory in factories)
            {
                if (factory.unitQueued == null)
                {
                    factory.unitQueued = cUnit.Rocket;
                    factory.unitsQueued = 1;
                    if (factoryMassProduction)
                        factory.timer = 74;
                    else
                        factory.timer = 98;
                    queuesToUpdate.Add(factory);
                }
            }
        }

        public override void AddUnits(ConstUnit unit, int amount)
        {
            base.AddUnits(unit, amount);
            if (unit == cUnit.Rocket && amount == 1)
                population += 6;
        }

        public override int GetCountByBuildingName(string name)
        {
            if (name == "manor")
                return manorcount;
            return base.GetCountByBuildingName(name);
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new BritishSettler());
        }

        //Add techs
        public override void AddMassProduction()
        {
            cUnit.Rocket.traintime = 74;
        }

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new BritishTownCenter());
            populationCap += 10;
        }

        public void AddManor()
        {
            AddVillager();
            population++;
            populationCap += 10;
        }

        public void AddBarracks()
        {
            unitBuildings.Add(new BritishBarracks());
        }

        public void AddStable()
        {
            unitBuildings.Add(new BritishStable());
        }

        //Add shipments
        public void AddVirginiaCompany()
        {
            virginiaCompany = true;
        }

        public void AddLongbowman6()
        {
            AddUnits(cUnit.Longbowman, 6);
        }

        public void AddLongbowman10()
        {
            AddUnits(cUnit.Longbowman, 10);
        }

        public void AddLongbowman8()
        {
            AddUnits(cUnit.Longbowman, 8);
        }

        public override void AddFactory()
        {
            unitBuildings.Add(new BritishFactory());
        }

        public override void AddRobberBarons()
        {
            unitBuildings.Add(new BritishFactory());
        }

        public void AddLongbowman20()
        {
            AddUnits(cUnit.Longbowman, 20);
        }

        public void AddRocket3()
        {
            AddUnits(cUnit.Rocket, 6);
        }

        public void AddRocket2()
        {
            AddUnits(cUnit.Rocket, 6);
        }

        //Add politicians
        public void AddAdventurer()
        {
            age = 3;
            AddUnits(cUnit.Longbowman, 7);
            population += 7;
        }

        public void AddViceroy()
        {
            age = 4;
            AddUnits(cUnit.Grenadier, 3);
            AddVillager(4);
            population += 10;
        }

        //Setup
        public override int FoodStart()
        {
            food = 275;
            wood = 65;
            coin = 30;
            AddVillager(9);
            manorcount = 1;
            populationCap = 20;
            xp = 160;
            return 56;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 260;
                wood = 0;
                coin = 30;
                AddVillager(10);
                manorcount = 1;
                populationCap = 20;
                xp = 0;
                shipmentsAvailable = 1;
                techBuildings.Add(new TradingPost());
                return 82;
            }
            else
            {
                food = 220;
                wood = 30;
                coin = 30;
                AddVillager(10);
                manorcount = 2;
                populationCap = 30;
                xp = 187;
                return 56;
            }
        }

        public override int CoinStart()
        {
            food = 220;
            wood = 15;
            AddVillager(10);
            techBuildings.Add(new EuropeanMarket());
            AddHuntingDogs();
            RemoveAllowedTech(cTech.HuntingDogs);
            manorcount = 1;
            populationCap = 20;
            xp = 256;
            return 81;
        }
    }
}
