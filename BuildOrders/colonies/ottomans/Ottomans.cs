using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Ottomans : EuropeanColony
    {
        // Crates: 3w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Ottomans(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
        }
        public Ottomans() { }

        public bool silkRoad;
        public bool mosque;
        public int villTrainTime = 48;
        public int villLimit = 25;

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.Vills3,
                cShipment.SilkRoad,
                cShipment.Crates300w,
                cShipment.Schooners,
                cShipment.AdvancedDock,

                //Colonial
                cShipment.Vills4,
                cShipment.RenderingPlant,
                cShipment.Crates600c,
                cShipment.Crates600w,
                cShipment.Crates700c,
                cShipment.Crates700w,
                cShipment.Crates700f,
                cShipment.Crates600f,

                cShipment.Janissary5,
                cShipment.Hussar3,

                //Fortress
                cShipment.Crates1000w,
                cShipment.Crates1000c,

                cShipment.Hussar5,
                cShipment.Janissary8,
                cShipment.AbusGun5,
                cShipment.CavalryArcher5,
                cShipment.Falconet2,
                cShipment.Spahi5,
                cShipment.Manchu9,
                cShipment.Mameluke4,

                //Industrial
                cShipment.Factory,
                cShipment.RobberBarons,

                cShipment.CavalryArcher9,
                cShipment.AbusGun12,
                cShipment.HeavyCannon2,
            });
        }

        public override void GatherFromTPs()
        {
            int tps = techBuildings.FindAll(building => building.GetType() == typeof(TradingPost)).Count;
            double sraddition = 0;

            if (silkRoad)
                sraddition = .5;

            if (stageCoach)
            {
                if (buildingsGathering == Resource.Default)
                    xp += tps * 2;
                else if (buildingsGathering == Resource.Food)
                    food += tps * (2 + sraddition);
                else if (buildingsGathering == Resource.Wood)
                    wood += tps * (2 + sraddition);
                else if (buildingsGathering == Resource.Coin)
                    coin += tps * (2 + sraddition);
            }
            else
                xp += tps * 1.1;
        }

        public override void Income()
        {
            base.Income();
            if (mosque)
                xp += .7;
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            if (amount == 1)
            {
                if (population < populationCap && villagers.Count < villLimit)
                    population++;
                else
                    return;
            }

            for (int i = 0; i < amount; i++)
                villagers.Add(new OttomanSettler());
        }

        //Add techs
        public void AddMilletSystem()
        {
            villTrainTime -= 5;
            AddAllowedTech(cTech.MilletSystem, cTech.KopruluViziers);
        }

        public void AddKopruluViziers()
        {
            villTrainTime -= 5;
            AddAllowedTech(cTech.KopruluViziers, cTech.AbbassidMarket);
        }

        public void AddAbbassidMarket()
        {
            villTrainTime -= 8;
        }

        public void AddTopkapi()
        {
            villLimit += 25;
            AddAllowedTech(cTech.Topkapi, cTech.Tanzimat);
        }

        public void AddGalataTowerDistrict()
        {
            villLimit += 20;
            AddAllowedTech(cTech.GalataTowerDistrict, cTech.Topkapi);
        }

        public void AddTanzimat()
        {
            villLimit += 29;
        }

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new OttomanTownCenter());
            populationCap += 10;
        }

        public void AddMosque()
        {
            techBuildings.Add(new Mosque());
            mosque = true;
        }

        public void AddBarracks()
        {
            unitBuildings.Add(new OttomanBarracks());
        }

        public void AddStable()
        {
            unitBuildings.Add(new OttomanStable());
        }

        //Add shipments
        public override void AddCrates300w()
        {
            woodCrateSeconds += 30;
            if (silkRoad)
                woodCrateSeconds += 8;
        }

        public override void AddCrates700w()
        {
            woodCrateSeconds += 70;
            if (silkRoad)
                woodCrateSeconds += 18;
        }

        public override void AddCrates600w()
        {
            woodCrateSeconds += 60;
            if (silkRoad)
                woodCrateSeconds += 15;
        }

        public override void AddCrates700c()
        {
            coinCrateSeconds += 70;
            if (silkRoad)
                woodCrateSeconds += 18;
        }

        public override void AddCrates600c()
        {
            coinCrateSeconds += 60;
            if (silkRoad)
                woodCrateSeconds += 15;
        }

        public override void AddCrates700f()
        {
            foodCrateSeconds += 70;
            if (silkRoad)
                woodCrateSeconds += 18;
        }

        public override void AddCrates600f()
        {
            foodCrateSeconds += 60;
            if (silkRoad)
                woodCrateSeconds += 15;
        }

        public override void AddCrates1000w()
        {
            woodCrateSeconds += 100;
            if (silkRoad)
                woodCrateSeconds += 25;
        }

        public override void AddCrates1000c()
        {
            coinCrateSeconds += 100;
            if (silkRoad)
                woodCrateSeconds += 25;
        }

        public void AddSilkRoad()
        {
            silkRoad = true;
        }

        public void AddJanissary5()
        {
            AddUnits(cUnit.Janissary, 5);
        }

        public void AddJanissary8()
        {
            AddUnits(cUnit.Janissary, 8);
        }

        public void AddAbusGun5()
        {
            AddUnits(cUnit.AbusGun, 5);
        }

        public void AddAbusGun12()
        {
            AddUnits(cUnit.AbusGun, 12);
        }

        public void AddSpahi5()
        {
            AddUnits(cUnit.Spahi, 5);
        }

        //Add politicians
        public void AddGrandVizier()
        {
            AddUnits(cUnit.Spahi, 3);
        }

        //Setup
        public override int FoodStart()
        {
            food = 530;
            wood = 0;
            coin = 30;
            AddVillager(8);
            populationCap = 20;
            shipmentsAvailable = 1;
            xp = 40;
            techBuildings.Add(new TradingPost());
            return 96;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 340;
                wood = 0;
                coin = 30;
                AddVillager(8);
                populationCap = 20;
                shipmentsAvailable = 1;
                xp = 75;
                techBuildings.Add(new TradingPost());
                techBuildings.Add(new TradingPost());
                return 96;
            }
            else
            {
                food = 320;
                wood = 0;
                coin = 30;
                AddVillager(8);
                populationCap = 20;
                shipmentsAvailable = 1;
                xp = 100;
                techBuildings.Add(new TradingPost());
                techBuildings.Add(new Mosque());
                AddMilletSystem();
                RemoveAllowedTech(cTech.MilletSystem);
                mosque = true;
                return 96;
            }
        }

        public override int CoinStart()
        {
            food = 480;
            wood = 0;
            coin = 130;
            AddVillager(8);
            populationCap = 20;
            shipmentsAvailable = 1;
            xp = 40;
            techBuildings.Add(new TradingPost());
            return 96;
        }
    }
}
