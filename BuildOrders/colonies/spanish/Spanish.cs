using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Spanish : EuropeanColony
    {
        //Crates: 2f 1w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Spanish(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
        }
        public Spanish() { }

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.Vills3,
                cShipment.Crates300w,
                cShipment.AdvancedTradingPost,
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

                cShipment.Pikeman8,
                cShipment.Rodelero6,
                cShipment.Rodelero7,

                //Fortress
                cShipment.Crates1000w,
                cShipment.Crates1000f,

                cShipment.Rodelero8,
                cShipment.Rodelero9,
                cShipment.Pikeman12,
                cShipment.Pikeman10,
                cShipment.Lancer5,
                cShipment.Lancer4,
                cShipment.Hussar5,
                cShipment.Falconet2,
                cShipment.Highlander9,
                cShipment.SwissPikeman12,

                //Industrial
                cShipment.Crates1600f,
                cShipment.Factory,
                cShipment.RobberBarons,

                cShipment.Lancer7,
                cShipment.Lancer8,
                cShipment.Pikeman24,
                cShipment.HeavyCannon2,
            });
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new SpanishSettler());
        }

        public override int XPtonextShipment()
        {
            int shipments = shipmentsAvailable + shipmentsSent.Count;
            switch (shipments)
            {
                case 0: return 225;
                case 1: return 259;
                case 2: return 298;
                case 3: return 342;
                case 4: return 394;
                case 5: return 453;
                case 6: return 520;
                case 7: return 599;
                case 8: return 688;
                case 9: return 792;
                case 10: return 910;

                default: return 910;
            }
        }

        //Add techs

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new SpanishTownCenter());
            populationCap += 10;
        }

        public void AddBarracks()
        {
            unitBuildings.Add(new SpanishBarracks());
        }

        public void AddStable()
        {
            unitBuildings.Add(new SpanishStable());
        }

        //Add shipments
        public void AddPikeman8()
        {
            AddUnits(cUnit.Pikeman, 8);
        }

        public void AddRodelero6()
        {
            AddUnits(cUnit.Rodelero, 6);
        }

        public void AddRodelero7()
        {
            AddUnits(cUnit.Rodelero, 7);
        }

        public void AddRodelero8()
        {
            AddUnits(cUnit.Rodelero, 8);
        }

        public void AddRodelero9()
        {
            AddUnits(cUnit.Rodelero, 9);
        }

        public void AddPikeman12()
        {
            AddUnits(cUnit.Pikeman, 12);
        }

        public void AddLancer5()
        {
            AddUnits(cUnit.Lancer, 5);
        }

        public void AddLancer4()
        {
            AddUnits(cUnit.Lancer, 4);
        }

        public void AddLancer7()
        {
            AddUnits(cUnit.Lancer, 7);
        }

        public void AddLancer8()
        {
            AddUnits(cUnit.Lancer, 8);
        }

        public void AddPikeman24()
        {
            AddUnits(cUnit.Pikeman, 24);
        }

        //Add politicians
        public void AddAdventurer()
        {
            age = 3;
            AddUnits(cUnit.Crossbowman, 4);
            AddUnits(cUnit.Pikeman, 4);
            population += 8;
        }

        public void AddSergeantAtArms()
        {
            age = 3;
            AddUnits(cUnit.Pikeman, 8);
            population += 8;
        }

        public void AddCavalryMarshal()
        {
            age = 4;
            AddUnits(cUnit.Lancer, 5);
            population += 10;
        }

        public void AddWarMinister()
        {
            age = 4;
            AddUnits(cUnit.Rodelero, 10);
            population += 10;
        }

        //Setup
        public override int FoodStart()
        {
            food = 330;
            wood = 0;
            coin = 30;
            AddVillager(8);
            populationCap = 20;
            xp = 153;
            return 56;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 160;
                wood = 0;
                coin = 30;
                AddVillager(9);
                populationCap = 20;
                shipmentsAvailable = 1;
                xp = 119;
                techBuildings.Add(new TradingPost());
                return 82;
            }
            else
            {
                food = 210;
                wood = 0;
                coin = 0;
                AddVillager(9);
                populationCap = 20;
                xp = 20;
                techBuildings.Add(new EuropeanMarket());
                AddHuntingDogs();
                RemoveAllowedTech(cTech.HuntingDogs);
                shipmentsAvailable = 1;
                return 82;
            }
        }

        public override int CoinStart()
        {
            food = 270;
            wood = 0;
            coin = 130;
            AddVillager(8);
            populationCap = 20;
            xp = 153;
            return 56;
        }
    }
}
