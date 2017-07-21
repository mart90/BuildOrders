using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Russians : EuropeanColony
    {
        //Crates: 5f 1w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Russians(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
        }
        public Russians() { }

        public bool distributivism;
        public bool boyars;

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.AdvancedTradingPost,
                cShipment.Distributivism,
                cShipment.Crates300w,

                //Colonial
                cShipment.Crates600c,
                cShipment.Crates600w,
                cShipment.Crates700c,
                cShipment.Crates700w,
                cShipment.Crates700f,
                cShipment.Crates600f,
                cShipment.SpiceTrade,
                cShipment.Boyars,

                cShipment.Cossack5,
                cShipment.Cossack4,
                cShipment.Strelet13,

                //Fortress
                cShipment.Crates1000w,
                cShipment.Crates1000c,
                cShipment.Crates1000f,

                cShipment.CavalryArcher5,
                cShipment.Cossack6,
                cShipment.Strelet20,
                cShipment.Falconet2,
                cShipment.Manchu9,
                cShipment.Highlander9,

                //Industrial
                cShipment.Crates1600w,
                cShipment.Crates1600c,
                cShipment.Crates1600f,
                cShipment.Factory,
                cShipment.RobberBarons,

                cShipment.CavalryArcher9,
                cShipment.Cossack9,
                cShipment.HeavyCannon2,
            });
        }

        public override void Income()
        {
            base.Income();
            if (distributivism)
                wood += 1.25;
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new RussianSettler());
        }

        //Add techs

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new RussianTownCenter());
            populationCap += 10;
        }

        public void AddBlockhouse()
        {
            unitBuildings.Add(new Blockhouse());
            populationCap += 5;
        }

        public void AddStable()
        {
            unitBuildings.Add(new RussianStable());
        }

        //Add shipments
        public void AddDistributivism()
        {
            distributivism = true;
        }

        public void AddBoyars()
        {
            boyars = true;
        }

        public void AddCossack5()
        {
            AddUnits(cUnit.Cossack, 5);
        }

        public void AddCossack4()
        {
            AddUnits(cUnit.Cossack, 4);
        }

        public void AddStrelet13()
        {
            AddUnits(cUnit.Strelet, 13);
        }

        public void AddCossack6()
        {
            AddUnits(cUnit.Cossack, 6);
        }

        public void AddStrelet20()
        {
            AddUnits(cUnit.Strelet, 20);
        }

        public void AddCossack9()
        {
            AddUnits(cUnit.Cossack, 9);
        }

        //Add politicians
        public override void AddMarksman()
        {
            age = 3;
            AddUnits(cUnit.Strelet, 17);
            population += 17;
        }

        public override void AddScout()
        {
            age = 3;
            AddUnits(cUnit.Cossack, 5);
            population += 5;
        }

        public override void AddKingsMusketeer()
        {
            age = 4;
            AddUnits(cUnit.Musketeer, 13);
            population += 13;
        }

        public void AddCavalryMarshal()
        {
            age = 4;
            AddUnits(cUnit.Cossack, 6);
            population += 6;
        }

        public void AddWarMinister()
        {
            age = 4;
            AddUnits(cUnit.Oprichnik, 7);
            population += 14;
        }

        //Setup
        public override int FoodStart()
        {
            food = 500;
            wood = 0;
            coin = 30;
            AddVillager(8);
            populationCap = 20;
            xp = 170;
            return 62;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 330;
                wood = 0;
                coin = 30;
                AddVillager(11);
                populationCap = 20;
                xp = 100;
                shipmentsAvailable = 1;
                techBuildings.Add(new TradingPost());
                return 115;
            }
            else
            {
                food = 400;
                wood = 0;
                coin = 0;
                AddVillager(11);
                populationCap = 20;
                xp = 20;
                shipmentsAvailable = 1;
                techBuildings.Add(new EuropeanMarket());
                AddHuntingDogs();
                RemoveAllowedTech(cTech.HuntingDogs);
                return 115;
            }
        }

        public override int CoinStart()
        {
            food = 440;
            wood = 0;
            coin = 130;
            AddVillager(8);
            populationCap = 20;
            xp = 170;
            return 62;
        }
    }
}
