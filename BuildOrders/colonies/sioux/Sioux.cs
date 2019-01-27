using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Sioux : NativeColony
    {
        //Crates: 3f +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Sioux(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            populationCap = 200;
            SetAllowedShipments();
        }
        public Sioux() { }

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.Vills3,
                cShipment.Crates300w,
                cShipment.AdvancedDock,

                //Colonial
                cShipment.Vills4,
                cShipment.Crates700w,
                cShipment.Crates600w,
                cShipment.Crates700c,
                cShipment.Crates600c,
                cShipment.Crates700f,
                //cShipment.NomadicExpansion,

                cShipment.CetanBow6,
                cShipment.WarClub7,
                cShipment.AxeRider4,
                cShipment.DogSoldier2,
               
                //Fortress
                cShipment.Crates1000w,
                cShipment.Crates1000f,

                cShipment.WakinaRifle9,
                cShipment.AxeRider5,
                cShipment.RifleRider4,
                cShipment.RifleRider5,
                cShipment.DogSoldier3,
                cShipment.SanteeSupport,
                cShipment.TwoKettleSupport,

                //Industrial
                cShipment.WakinaRifle18,
                cShipment.AxeRider8,
            });
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new SiouxVillager());
        }

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new SiouxTownCenter());
            populationCap += 10;
        }

        public override void AddFirePit()
        {
            firePit = new SiouxFirePit();
        }

        public override void AddWarHut()
        {
            unitBuildings.Add(new SiouxWarHut());
        }

        public void AddCorral()
        {
            unitBuildings.Add(new SiouxCorral());
        }

        //Add techs

        //Add shipments
        public void AddNomadicExpansion()
        {
            //TODO
        }

        public void AddCetanBow6()
        {
            AddUnits(cUnit.CetanBow, 6);
        }

        public void AddWarClub7()
        {
            AddUnits(cUnit.WarClub, 7);
        }

        public void AddAxeRider4()
        {
            AddUnits(cUnit.AxeRider, 4);
        }

        public void AddDogSoldier2()
        {
            AddUnits(cUnit.DogSoldier, 2);
        }

        public void AddWakinaRifle9()
        {
            AddUnits(cUnit.WakinaRifle, 9);
        }

        public void AddAxeRider5()
        {
            AddUnits(cUnit.AxeRider, 5);
        }

        public void AddRifleRider4()
        {
            AddUnits(cUnit.RifleRider, 4);
        }

        public void AddRifleRider5()
        {
            AddUnits(cUnit.RifleRider, 5);
        }

        public void AddDogSoldier3()
        {
            AddUnits(cUnit.DogSoldier, 3);
        }

        public void AddSanteeSupport()
        {
            AddUnits(cUnit.AxeRider, 6);
        }

        public void AddTwoKettleSupport()
        {
            AddUnits(cUnit.WakinaRifle, 14);
        }

        public void AddWakinaRifle18()
        {
            AddUnits(cUnit.WakinaRifle, 18);
        }

        public void AddAxeRider8()
        {
            AddUnits(cUnit.AxeRider, 8);
        }

        //Add politicians
        public override void AddWiseWoman()
        {
            age++;
            switch (age)
            {
                case 2:
                    foodGatherRateBonus += .1m;
                    break;
                case 3:
                    foodGatherRateBonus += .2m;
                    break;
                case 4:
                    foodGatherRateBonus += .3m;
                    break;
            }
        }

        public override void AddChief()
        {
            age++;
            switch (age)
            {
                case 2:
                    woodCrateSeconds += 40;
                    break;
                case 3:
                    woodCrateSeconds += 80;
                    break;
                case 4:
                    woodCrateSeconds += 120;
                    break;
            }
        }

        public override void AddMessenger()
        {
            age++;
        }

        public override void AddWarrior()
        {
            age++;
            var axeriderstoadd = 0;
            switch (age)
            {
                case 2:
                    axeriderstoadd = 1;
                    break;
                case 3:
                    axeriderstoadd = 4;
                    break;
                case 4:
                    axeriderstoadd = 5;
                    break;
            }

            AddUnits(cUnit.AxeRider, axeriderstoadd);
            population += axeriderstoadd * 2;
        }

        public override void AddShaman()
        {
            age++;
            switch (age)
            {
                case 2:
                    foodCrateSeconds += 50;
                    break;
                case 3:
                    foodCrateSeconds += 100;
                    break;
                case 4:
                    foodCrateSeconds += 150;
                    break;
            }
        }

        //Setup
        public override int FoodStart()
        {
            food = 360;
            wood = 0;
            coin = 30;
            AddVillager(6);
            xp = 75;
            return 31;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 250;
                wood = 0;
                coin = 30;
                AddVillager(9);
                techBuildings.Add(new TradingPost());
                shipmentsAvailable = 1;
                xp = 80;
                return 106;
            }
            else
            {
                food = 230;
                wood = 0;
                coin = 0;
                AddVillager(8);
                techBuildings.Add(new NativeMarket());
                AddHuntingDogs();
                RemoveAllowedTech(cTech.HuntingDogs);
                xp = 220;
                return 81;
            }
        }

        public override int CoinStart()
        {
            food = 350;
            wood = 0;
            coin = 30;
            AddVillager(7);
            xp = 130;
            return 56;
        }
    }
}
