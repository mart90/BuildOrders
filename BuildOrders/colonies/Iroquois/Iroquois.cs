using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Iroquois : NativeColony
    {
        // Crates: 4f +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Iroquois(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new IroquoisTownCenter());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
        }
        public Iroquois() { }

        public string travoisBuilding = "WarHut";

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.Vills3,
                cShipment.Crates300w,

                //Colonial
                cShipment.Vills4,
                cShipment.Vills5,
                cShipment.Crates600w,
                cShipment.Crates600c,

                cShipment.Aenna7,
                cShipment.Aenna6,
                cShipment.KanyaHorseman4,
                cShipment.Tomahawk6,

                //Fortress
                cShipment.Crates1200,

                cShipment.ForestProwler8,
                cShipment.ForestProwler6,
                cShipment.Tomahawk9,
                cShipment.Tomahawk8,
                cShipment.MusketRider5,
                cShipment.KanyaHorseman6,
                cShipment.KanyaHorseman5,
                cShipment.Mantlet5,
                cShipment.RenegadeFrench,

                //Industrial
                cShipment.Crates1800,
                cShipment.Crates1500,

                cShipment.Tomahawk16,
                cShipment.LightCannon4,
            });
        }

        public IroquoisFirePit MyFirePit()
        {
            return firePit == null ? null : (IroquoisFirePit)firePit;
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new IroquoisVillager());
        }

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new IroquoisTownCenter());
            populationCap += 10;
        }

        public void AddLonghouse()
        {
            populationCap += 15;
        }

        public override void AddFirePit()
        {
            firePit = new IroquoisFirePit();
        }

        public override void AddWarHut()
        {
            unitBuildings.Add(new IroquoisWarHut());
        }

        public void AddCorral()
        {
            unitBuildings.Add(new IroquoisCorral());
        }

        public void AddArtilleryFoundry()
        {
            unitBuildings.Add(new IroquoisArtilleryFoundry());
        }

        //Add techs

        //Add shipments
        public void AddAenna7()
        {
            AddUnits(cUnit.Aenna, 7);
        }

        public void AddAenna6()
        {
            AddUnits(cUnit.Aenna, 6);
        }

        public void AddKanyaHorseman4()
        {
            AddUnits(cUnit.KanyaHorseman, 4);
        }

        public void AddTomahawk6()
        {
            AddUnits(cUnit.Tomahawk, 6);
        }

        public void AddCrates1200()
        {
            foodCrateSeconds += 40;
            woodCrateSeconds += 40;
            coinCrateSeconds += 40;
        }

        public void AddForestProwler8()
        {
            AddUnits(cUnit.ForestProwler, 8);
        }

        public void AddForestProwler6()
        {
            AddUnits(cUnit.ForestProwler, 6);
        }

        public void AddTomahawk9()
        {
            AddUnits(cUnit.Tomahawk, 9);
        }

        public void AddTomahawk8()
        {
            AddUnits(cUnit.Tomahawk, 8);
        }

        public void AddMusketRider5()
        {
            AddUnits(cUnit.MusketRider, 5);
        }

        public void AddKanyaHorseman6()
        {
            AddUnits(cUnit.KanyaHorseman, 6);
        }

        public void AddKanyaHorseman5()
        {
            AddUnits(cUnit.KanyaHorseman, 5);
        }

        public void AddMantlet5()
        {
            AddUnits(cUnit.Mantlet, 5);
        }

        public void AddRenegadeFrench()
        {
            AddUnits(cUnit.Cuirassier, 5);
        }

        public void AddCrates1800()
        {
            foodCrateSeconds += 60;
            woodCrateSeconds += 60;
            coinCrateSeconds += 60;
        }

        public void AddCrates1500()
        {
            foodCrateSeconds += 50;
            woodCrateSeconds += 50;
            coinCrateSeconds += 50;
        }

        public void AddTomahawk16()
        {
            AddUnits(cUnit.Tomahawk, 16);
        }

        public void AddLightCannon4()
        {
            AddUnits(cUnit.LightCannon, 4);
        }

        //Add politicians
        public override void AddWiseWoman()
        {
            age++;
            var travoisbuilding = cBuilding.GetFieldByName(travoisBuilding);
            MakeBuildingFromWagon(travoisbuilding, 30);
            switch (age)
            {
                case 2:
                    foodCrateSeconds += 20;
                    woodCrateSeconds += 10;
                    coinCrateSeconds += 10;
                    break;
                case 3:
                    foodCrateSeconds += 30;
                    woodCrateSeconds += 20;
                    coinCrateSeconds += 20;
                    break;
                case 4:
                    foodCrateSeconds += 40;
                    woodCrateSeconds += 30;
                    coinCrateSeconds += 30;
                    break;
            }
        }

        public override void AddChief()
        {
            age++;
            var travoisbuilding = cBuilding.GetFieldByName(travoisBuilding);
            MakeBuildingFromWagon(travoisbuilding, 30);
            var villstoadd = 0;
            switch (age)
            {
                case 2:
                    villstoadd = 2;
                    break;
                case 3:
                    villstoadd = 4;
                    break;
                case 4:
                    villstoadd = 10;
                    break;
            }

            AddUnits(cUnit.Villager, villstoadd);
            population += villstoadd;
        }

        public override void AddMessenger()
        {
            age++;
            var travoisbuilding = cBuilding.GetFieldByName(travoisBuilding);
            MakeBuildingFromWagon(travoisbuilding, 30);
        }

        public override void AddWarrior()
        {
            age++;
            var travoisbuilding = cBuilding.GetFieldByName(travoisBuilding);
            MakeBuildingFromWagon(travoisbuilding, 30);
            int mantletstoadd = 0;
            switch (age)
            {
                case 2:
                    mantletstoadd = 1;
                    break;
                case 3:
                    mantletstoadd = 4;
                    break;
                case 4:
                    mantletstoadd = 5;
                    break;
            }

            AddUnits(cUnit.Mantlet, mantletstoadd);
            population += mantletstoadd * 2;
        }

        public override void AddShaman()
        {
            age++;
            var travoisbuilding = cBuilding.GetFieldByName(travoisBuilding);
            MakeBuildingFromWagon(travoisbuilding, 30);
            switch (age)
            {
                case 2:
                    MakeBuildingFromWagon(travoisbuilding, 30);
                    break;
                case 3:
                    MakeBuildingFromWagon(travoisbuilding, 30);
                    MakeBuildingFromWagon(travoisbuilding, 30);
                    break;
                case 4:
                    MakeBuildingFromWagon(travoisbuilding, 30);
                    MakeBuildingFromWagon(travoisbuilding, 30);
                    MakeBuildingFromWagon(travoisbuilding, 30);
                    break;
            }
        }

        //Setup
        public override int FoodStart()
        {
            food = 390;
            wood = 0;
            coin = 30;
            AddVillager(7);
            populationCap = 25;
            xp = 160;
            return 56;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 257;
                wood = 0;
                coin = 30;
                AddVillager(9);
                populationCap = 25;
                techBuildings.Add(new TradingPost());
                shipmentsAvailable = 1;
                xp = 100;
                return 106;
            }
            else
            {
                food = 300;
                wood = 0;
                coin = 0;
                AddVillager(9);
                populationCap = 25;
                techBuildings.Add(new NativeMarket());
                AddHuntingDogs();
                RemoveAllowedTech(cTech.HuntingDogs);
                shipmentsAvailable = 1;
                xp = 5;
                return 106;
            }
        }

        public override int CoinStart()
        {
            food = 340;
            wood = 0;
            coin = 130;
            AddVillager(7);
            populationCap = 25;
            xp = 160;
            return 56;
        }
    }
}
