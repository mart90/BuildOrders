using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Germans : EuropeanColony
    {
        //Crates: 2f 1w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Germans(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            settlerWagoncount = 3;
            SetAllowedShipments();
        }
        public Germans() { }

        public int settlerWagoncount;

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.SettlerWagon2,
                cShipment.Crates300w,

                //Colonial
                cShipment.ColoSettlerWagon2,
                cShipment.SettlerWagon3,
                cShipment.Crates600c,
                cShipment.Crates600w,
                cShipment.Crates700c,
                cShipment.Crates700w,
                cShipment.Crates700f,
                cShipment.Crates600f,
                cShipment.SpiceTrade,

                cShipment.Uhlan3,
                cShipment.Doppelsoldner3,
                cShipment.Crossbowman8,

                //Fortress
                cShipment.Crates1000w,
                cShipment.Crates1000c,
                cShipment.Crates1000f,

                cShipment.Doppelsoldner5,
                cShipment.Skirmisher7,
                cShipment.Skirmisher8,
                cShipment.Uhlan5,
                cShipment.Uhlan6,
                cShipment.WarWagon3,
                cShipment.Jaeger13,
                cShipment.BlackRider9,

                //Industrial
                cShipment.Factory,
                cShipment.RobberBarons,

                cShipment.Doppelsoldner9,
                cShipment.Skirmisher12,
                cShipment.Uhlan9,
                cShipment.PolishWingedHussars,
                cShipment.HeavyCannon2,
            });
        }

        public override void AddShipment(ConstShipment shipment)
        {
            base.AddShipment(shipment);
            if (age > 1)
            {
                if (shipment.name == "PolishWingedHussars")
                    return;

                AddUnits(cUnit.Uhlan, age);
            }
        }

        public override int XPtonextShipment()
        {
            int shipments = shipmentsAvailable + shipmentsSent.Count;
            switch (shipments)
            {
                case 0: return 330;
                case 1: return 380;
                case 2: return 436;
                case 3: return 502;
                case 4: return 577;
                case 5: return 664;
                case 6: return 763;
                case 7: return 878;
                case 8: return 1009;
                case 9: return 1161;
                case 10: return 1335;

                default: return 1335;
            }
        }

        public override void Gather()
        {
            base.Gather();
            //SettlerWagonNerf(); // For testing purposes
        }

        public void SettlerWagonNerf()
        {
            double nerf = .95;

            if (FoodGatherers().Count >= Math.Max(WoodGatherers().Count, CoinGatherers().Count))
                food -= foodBaseGatherRate * (double)foodGatherRateBonus * (1 - nerf) * settlerWagoncount * 2;
            else if (WoodGatherers().Count > CoinGatherers().Count)
                wood -= woodBaseGatherRate * (double)woodGatherRateBonus * (1 - nerf) * settlerWagoncount * 2;
            else
                coin -= coinBaseGatherRate * (double)coinGatherRateBonus * (1 - nerf) * settlerWagoncount * 2;
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new GermanSettler());
        }

        //Add techs

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new GermanTownCenter());
            populationCap += 10;
        }

        public void AddBarracks()
        {
            unitBuildings.Add(new GermanBarracks());
        }

        public void AddStable()
        {
            unitBuildings.Add(new GermanStable());
        }

        //Add shipments
        public void AddSettlerWagon2()
        {
            AddVillager(4);
            settlerWagoncount += 2;
        }

        public void AddColoSettlerWagon2()
        {
            AddVillager(4);
            settlerWagoncount += 2;
        }

        public void AddSettlerWagon3()
        {
            AddVillager(6);
            settlerWagoncount += 3;
        }

        public void AddUhlan3()
        {
            AddUnits(cUnit.Uhlan, 3);
        }
        public void AddDoppelsoldner3()
        {
            AddUnits(cUnit.Doppelsoldner, 3);
        }

        public void AddDoppelsoldner5()
        {
            AddUnits(cUnit.Doppelsoldner, 5);
        }

        public void AddUhlan5()
        {
            AddUnits(cUnit.Uhlan, 5);
        }

        public void AddUhlan6()
        {
            AddUnits(cUnit.Uhlan, 6);
        }

        public void AddWarWagon3()
        {
            AddUnits(cUnit.WarWagon, 3);
        }

        public void AddDoppelsoldner9()
        {
            AddUnits(cUnit.Doppelsoldner, 9);
        }

        public void AddSkirmisher12()
        {
            AddUnits(cUnit.Skirmisher, 12);
        }

        public void AddUhlan9()
        {
            AddUnits(cUnit.Uhlan, 9);
        }

        public void AddPolishWingedHussars()
        {
            AddUnits(cUnit.WingedHussar, 10);
        }

        //Add politicians
        public void AddSergeantAtArms()
        {
            age = 3;
            AddUnits(cUnit.Doppelsoldner, 3);
            population += 6;
        }

        public void AddViceroy()
        {
            age = 4;
            AddUnits(cUnit.Uhlan, 3);
            AddVillager(4);
            population += 10;
        }

        public void AddCavalryMarshal()
        {
            age = 4;
            AddUnits(cUnit.Uhlan, 6);
            population += 12;
        }

        //Setup
        public override int FoodStart()
        {
            food = 310;
            wood = 0;
            coin = 30;
            AddVillager(8);
            populationCap = 20;
            xp = 145;
            return 53;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 230;
                wood = 0;
                coin = 30;
                AddVillager(10);
                populationCap = 20;
                xp = 60;
                shipmentsAvailable = 1;
                techBuildings.Add(new TradingPost());
                return 105;
            }
            else
            {
                food = 175;
                wood = 0;
                coin = 0;
                AddVillager(9);
                populationCap = 20;
                xp = 230;
                techBuildings.Add(new EuropeanMarket());
                AddHuntingDogs();
                RemoveAllowedTech(cTech.HuntingDogs);
                return 80;
            }
        }

        public override int CoinStart()
        {
            food = 260;
            wood = 0;
            coin = 130;
            AddVillager(8);
            populationCap = 20;
            xp = 145;
            return 53;
        }
    }
}
