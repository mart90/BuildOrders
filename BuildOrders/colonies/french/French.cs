using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class French : EuropeanColony
    {
        //Crates: 3f 1w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public French(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
        }
        public French() { }
        
        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.Vills3,
                cShipment.EconomicTheory,

                //Colonial
                cShipment.Vills4,
                cShipment.Crates600c,
                cShipment.Crates600w,
                cShipment.Crates700c,
                cShipment.Crates700w,
                cShipment.Crates700f,
                cShipment.Crates600f,
                cShipment.SpiceTrade,

                cShipment.Crossbowman8,
                cShipment.Hussar3,

                //Fortress
                cShipment.Crates1000w,
                cShipment.Crates1000c,
                cShipment.Crates1000f,

                cShipment.Skirmisher8,
                cShipment.Skirmisher7,
                cShipment.Dragoon5,
                cShipment.Cuirassier3,
                cShipment.Falconet2,
                cShipment.BlackRider7,
                cShipment.Jaeger10,
                cShipment.SwissPikeman12,

                //Industrial
                cShipment.Factory,
                cShipment.RobberBarons,

                cShipment.Crates1600w,
                cShipment.HeavyCannon2,
            });
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new Coureur());
        }

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new FrenchTownCenter());
            populationCap += 10;
        }

        //Add shipments
        public void AddCuirassier3()
        {
            AddUnits(cUnit.Cuirassier, 3);
        }

        //Add politicians
        public void AddCavalryMarshal()
        {
            AddUnits(cUnit.Cuirassier, 3);
            population += 9;
        }

        //Setup
        public override int FoodStart()
        {
            food = 310;
            wood = 0;
            coin = 0;
            AddVillager(9);
            shipmentsAvailable = 1;
            populationCap = 20;
            xp = 20;
            techBuildings.Add(new EuropeanMarket());
            AddHuntingDogs();
            RemoveAllowedTech(cTech.HuntingDogs);
            return 122;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 270;
                wood = 0;
                coin = 30;
                AddVillager(8);
                shipmentsAvailable = 1;
                populationCap = 20;
                xp = 60;
                techBuildings.Add(new TradingPost());
                return 95;
            }
            else
            {
                food = 320;
                wood = 100;
                coin = 30;
                AddVillager(8);
                populationCap = 20;
                xp = 275;
                techBuildings.Add(new EuropeanMarket());
                AddHuntingDogs();
                RemoveAllowedTech(cTech.HuntingDogs);
                return 95;
            }
        }

        public override int CoinStart()
        {
            food = 340;
            wood = 0;
            coin = 80;
            AddVillager(9);
            shipmentsAvailable = 1;
            populationCap = 20;
            xp = 50;
            techBuildings.Add(new EuropeanMarket());
            AddHuntingDogs();
            RemoveAllowedTech(cTech.HuntingDogs);
            return 122;
        }
    }
}
