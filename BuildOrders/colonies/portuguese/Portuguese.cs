using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Portuguese : EuropeanColony
    {
        //Crates: 1f 1w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Portuguese(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
        }
        public Portuguese() { }

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.Crates300w,
                cShipment.EconomicTheory,
                cShipment.AdvancedTradingPost,
                
                //Colonial
                cShipment.Crates700c,
                cShipment.Crates700f,
                cShipment.Crates700w,
                cShipment.Crates600c,
                cShipment.Crates600w,
                cShipment.SpiceTrade,

                cShipment.Crossbowman8,
                cShipment.Musketeer6,

                //Fortress
                cShipment.Crates1000c,
                cShipment.Crates1000w,
                cShipment.Crates1000f,

                cShipment.Cassador8,
                cShipment.Cassador7,
                cShipment.OrganGun2,
                cShipment.Dragoon5,
                cShipment.Mameluke4,

                //Industrial                
                cShipment.Factory,
                cShipment.RobberBarons,

                cShipment.Musketeer16,
                cShipment.Dragoon8,
                cShipment.HeavyCannon2,
                cShipment.OrganGun5,
            });
        }

        public void AddFreeTC()
        {
            MakeBuildingFromWagon(cBuilding.TownCenter, 60);
        }

        public override void AddTech(ConstTech tech)
        {
            base.AddTech(tech);

            if (FindBuildingsByName("TownCenter").Find(building => building.techQueued.name == tech.name) != null)
                AddFreeTC();
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new PortugueseSettler());
        }

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new PortugueseTownCenter());
            populationCap += 10;
        }

        public void AddBarracks()
        {
            unitBuildings.Add(new PortugueseBarracks());
        }

        public void AddStable()
        {
            unitBuildings.Add(new PortugueseStable());
        }

        public override void AddArtilleryFoundry()
        {
            unitBuildings.Add(new PortugueseArtilleryFoundry());
        }

        //Add shipments
        public void AddOrganGun2()
        {
            AddUnits(cUnit.OrganGun, 2);
        }

        public void AddOrganGun5()
        {
            AddUnits(cUnit.OrganGun, 5);
        }

        public void AddMusketeer16()
        {
            AddUnits(cUnit.Musketeer, 16);
        }

        public void AddDragoon8()
        {
            AddUnits(cUnit.Dragoon, 8);
        }

        //Add politicians
        public override void AddMarksman()
        {
            age = 3;
            AddUnits(cUnit.Cassadore, 6);
            population += 6;
        }

        public override void AddEngineer()
        {
            age = 4;
            AddUnits(cUnit.OrganGun, 2);
            population += 8;
        }

        public void AddViceroy()
        {
            age = 4;
            AddUnits(cUnit.Dragoon, 3);
            AddVillager(4);
            population += 10;
        }

        //Setup
        public override int FoodStart()
        {
            food = 290;
            wood = 0;
            coin = 30;
            AddVillager(9);
            populationCap = 20;
            xp = 150;
            return 56;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 180;
                wood = 0;
                coin = 30;
                AddVillager(10);
                populationCap = 20;
                shipmentsAvailable = 1;
                xp = 40;
                techBuildings.Add(new TradingPost());
                return 82;
            }
            else
            {
                food = 220;
                wood = 0;
                coin = 0;
                AddVillager(10);
                populationCap = 20;
                xp = 240;
                techBuildings.Add(new EuropeanMarket());
                AddHuntingDogs();
                RemoveAllowedTech(cTech.HuntingDogs);
                return 82;
            }
        }

        public override int CoinStart()
        {
            food = 240;
            wood = 0;
            coin = 130;
            AddVillager(9);
            populationCap = 20;
            xp = 150;
            return 56;
        }
    }
}
