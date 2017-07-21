using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Dutch : EuropeanColony
    {
        //Crates: 4c 1w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Dutch(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
        }
        public Dutch() { }

        public int bankCount;
        public int bankLimit = 5;

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.Vills3,
                cShipment.Crates300w,
                cShipment.BankOfAmsterdam,
                cShipment.BankOfRotterdam,

                //Colonial
                cShipment.Vills4,
                cShipment.Crates600c,
                cShipment.Crates600w,
                cShipment.Crates700c,
                cShipment.Crates700w,
                cShipment.Crates700f,
                cShipment.Crates600f,
                cShipment.BankWagon,

                cShipment.Pikeman8,
                cShipment.Hussar3,

                //Fortress
                cShipment.Crates1000w,
                cShipment.Crates1000c,
                cShipment.Crates1000f,

                cShipment.Skirmisher7,
                cShipment.Skirmisher8,
                cShipment.Ruyter7,
                cShipment.Ruyter9,
                cShipment.BlackRider7,
                cShipment.SwissPikeman12,

                //Industrial
                cShipment.Factory,
                cShipment.RobberBarons,

                cShipment.Skirmisher14,
                cShipment.Ruyter17,
                cShipment.HeavyCannon2,
            });
        }

        public override void Income()
        {
            BankIncome();
            base.Income();
        }

        public void BankIncome()
        {
            coin += bankCount * 2.75;
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new DutchSettler());
        }

        //Add techs

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new DutchTownCenter());
            populationCap += 10;
        }

        public void AddBarracks()
        {
            unitBuildings.Add(new DutchBarracks());
        }

        public void AddStable()
        {
            unitBuildings.Add(new DutchStable());
        }

        public void AddBank()
        {
            bankCount++;
        }

        //Add shipments
        public void AddBankOfAmsterdam()
        {
            bankLimit++;
        }

        public void AddBankOfRotterdam()
        {
            bankLimit++;
        }

        public void AddBankWagon()
        {
            if (bankCount < bankLimit)
                MakeBuildingFromWagon(cBuilding.Bank, 10);
        }

        public void AddRuyter7()
        {
            AddUnits(cUnit.Ruyter, 7);
        }

        public void AddRuyter9()
        {
            AddUnits(cUnit.Ruyter, 9);
        }

        public void AddSkirmisher14()
        {
            AddUnits(cUnit.Skirmisher, 14);
        }

        public void AddRuyter17()
        {
            AddUnits(cUnit.Ruyter, 17);
        }

        //Add politicians
        public void AddSergeantAtArms()
        {
            age = 3;
            AddUnits(cUnit.Halberdier, 5);
            population += 5;
        }

        public override void AddKingsMusketeer()
        {
            age = 4;
            AddUnits(cUnit.Skirmisher, 8);
            population += 8;
        }

        public void AddViceroy()
        {
            age = 4;
            AddUnits(cUnit.Ruyter, 5);
            AddVillager(4);
            population += 9;
        }

        public void AddCavalryMarshal()
        {
            age = 4;
            AddUnits(cUnit.Ruyter, 9);
            population += 9;
        }

        //Setup
        public override int FoodStart()
        {
            food = 310;
            wood = 0;
            coin = 260;
            AddVillager(9);
            AllocateVills(1, 0, 0);
            SwitchVills(Resource.Food, Resource.Coin, 3);
            populationCap = 20;
            xp = 211;
            return 82;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 220;
                wood = 0;
                coin = 180;
                AddVillager(10);
                AllocateVills(1, 0, 0);
                SwitchVills(Resource.Food, Resource.Coin, 2);
                populationCap = 20;
                shipmentsAvailable = 1;
                xp = 100;
                techBuildings.Add(new TradingPost());
                return 106;
            }
            else
            {
                food = 170;
                wood = 100;
                coin = 290;
                AddVillager(8);
                AllocateVills(1, 0, 0);
                SwitchVills(Resource.Food, Resource.Coin, 3);
                populationCap = 20;
                xp = 150;
                return 56;
            }
        }

        public override int CoinStart()
        {
            food = 170;
            wood = 0;
            coin = 380;
            AddVillager(8);
            AllocateVills(1, 0, 0);
            SwitchVills(Resource.Food, Resource.Coin, 2);
            populationCap = 20;
            xp = 150;
            return 54;
        }
    }
}
