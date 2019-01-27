using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Indians : AsianColony
    {
        // Crates: 1f 3w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Indians(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            explorers.Add(new Explorer());
            woodGatherRateBonus += 0.15m;
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
        }
        public Indians() { }

        //Shipments
        public bool distributivism;
        public bool foreignLogging;

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            { 
                //Discovery
                cShipment.Distributivism,
                cShipment.GoodFaithAgreements,
                cShipment.EconomicTheory,
                cShipment.AdvancedDock,
                cShipment.EastIndiamen,

                //Colonial
                cShipment.Export300,
                cShipment.RenderingPlant,
                cShipment.Crates600c,
                cShipment.Crates600w,
                cShipment.Crates700f,
                cShipment.SpiceTrade,
                cShipment.ForeignLogging,

                cShipment.Sepoy5,
                cShipment.Sowar4,

                //Fortress
                cShipment.Crates1000c,
                cShipment.Crates1000w,
                cShipment.Crates1000f,

                cShipment.Urumi7,
                cShipment.Sepoy9,
                cShipment.Gurkha8,
                cShipment.Gurkha7,
                cShipment.Mahout2,
                cShipment.Mahout3,
                cShipment.Zamburak8,
                cShipment.Zamburak9,
                cShipment.Intervention,
                cShipment.Howdah2,
                cShipment.SiegeElephant2,

                //Industrial
                cShipment.Crates1600w,

                cShipment.Urumi9,
                cShipment.UrumiRegiment,
            });
        }

        public IndianConsulate MyConsulate()
        {
            return (IndianConsulate)consulate;
        }

        public override void AddShipment(ConstShipment shipment)
        {
            base.AddShipment(shipment);
            AddVillager();
            population++;
        }

        public override void Income()
        {
            base.Income();
            if (distributivism)
                wood += 1.25;
            if (foreignLogging)
                wood += 2.5;
        }

        public override int XPtonextShipment()
        {
            int shipments = shipmentsAvailable + shipmentsSent.Count;
            switch (shipments)
            {
                case 0: return 324;
                case 1: return 373;
                case 2: return 428;
                case 3: return 493;
                case 4: return 567;
                case 5: return 652;
                case 6: return 749;
                case 7: return 862;
                case 8: return 991;
                case 9: return 1140;
                case 10: return 1311;

                default: return 324;
            }
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new IndianVillager());
        }

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new IndianTownCenter());
            populationCap += 10;
        }

        public override void AddConsulate()
        {
            consulate = new IndianConsulate();
            unitBuildings.Add(consulate);
        }

        public void AddCaravanserai()
        {
            unitBuildings.Add(new Caravanserai());
        }

        public void AddBarracks()
        {
            unitBuildings.Add(new IndianBarracks());
        }

        public override void AddHouse()
        {
            populationCap += 10;
        }

        public override void AddMarket()
        {
            AsianMarket market = new AsianMarket();
            market.allowedTechs.Remove(cTech.WaterWheel);
            market.allowedTechs.Add(cTech.TimberTrade);
            techBuildings.Add(market);
        }

        public override void AddCastle()
        {
            unitBuildings.Add(new IndianCastle());
        }

        //Add techs
        public override void AddCancelAlliance()
        {
            var consulate = MyConsulate();
            if (consulate.alliance == Alliance.French)
            {
                foodGatherRateBonus -= .05m;
                woodGatherRateBonus -= .05m;
                coinGatherRateBonus -= .05m;
            }
            base.AddCancelAlliance();
        }

        public void AddAllyBritish()
        {
            MyConsulate().SetAllyBritish();
        }

        public void AddAllyFrench()
        {
            MyConsulate().SetAllyFrench();
            foodGatherRateBonus += .05m;
            woodGatherRateBonus += .05m;
            coinGatherRateBonus += .05m;
        }

        public void AddAllyOttomans()
        {
            MyConsulate().SetAllyOttomans();
        }

        new public void AddVills4()
        {
            AddVillager(4);
            consulate.allowedTechs.Remove(cTech.Vills4);
        }

        public void AddOttomanExpeditionaryCompany()
        {
            AddUnits(cUnit.GardenerHussar, 3);
            population += 6;
        }

        //Add shipments
        public void AddDistributivism()
        {
            distributivism = true;
        }

        public void AddForeignLogging()
        {
            foreignLogging = true;
        }

        public void AddSepoy5()
        {
            AddUnits(cUnit.Sepoy, 5);
        }

        public void AddSowar4()
        {
            AddUnits(cUnit.Sowar, 4);
        }
        
        public void AddUrumi7()
        {
            AddUnits(cUnit.Urumi, 7);
        }

        public void AddSepoy9()
        {
            AddUnits(cUnit.Sepoy, 9);
        }

        public void AddGurkha8()
        {
            AddUnits(cUnit.Gurkha, 8);
        }

        public void AddGurkha7()
        {
            AddUnits(cUnit.Gurkha, 7);
        }

        public void AddMahout2()
        {
            AddUnits(cUnit.Mahout, 2);
        }

        public void AddMahout3()
        {
            AddUnits(cUnit.Mahout, 3);
        }

        public void AddZamburak9()
        {
            AddUnits(cUnit.Zamburak, 9);
        }

        public void AddZamburak8()
        {
            AddUnits(cUnit.Zamburak, 8);
        }

        public void AddHowdah2()
        {
            AddUnits(cUnit.Howdah, 2);
        }

        public void AddSiegeElephant2()
        {
            AddUnits(cUnit.SiegeElephant, 2);
        }

        public void AddUrumi9()
        {
            AddUnits(cUnit.Urumi, 9);
        }

        public void AddUrumiRegiment()
        {
            AddUnits(cUnit.Urumi, 11);
        }

        //Add wonders
        public void AddAgraFort()
        {
            age++;
            unitBuildings.Add(new IndianBarracks());
            xp -= 20;
            switch (age)
            {
                case 2:
                    AddUnits(cUnit.Sepoy, 2);
                    population += 2;
                    break;
                case 3:
                    AddUnits(cUnit.Gurkha, 5);
                    population += 5;
                    break;
                case 4:
                    AddUnits(cUnit.Gurkha, 7);
                    population += 7;
                    break;
            }
        }

        public void AddKarniMata()
        {
            age++;
            foodGatherRateBonus += .09m;
            woodGatherRateBonus += .09m;
            coinGatherRateBonus += .09m;
            switch (age)
            {
                case 2:
                    foodCrateSeconds += 20;
                    woodCrateSeconds += 20;
                    coinCrateSeconds += 12;
                    break;
                case 3:
                    foodCrateSeconds += 40;
                    woodCrateSeconds += 30;
                    coinCrateSeconds += 30;
                    break;
                case 4:
                    foodCrateSeconds += 40;
                    woodCrateSeconds += 50;
                    coinCrateSeconds += 50;
                    break;
            }
        }

        public void AddTowerOfVictory()
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

        public void AddTajMahal()
        {
            age++;
            switch (age)
            {
                case 2:
                    coinCrateSeconds += 50;
                    break;
                case 3:
                    coinCrateSeconds += 80;
                    break;
                case 4:
                    coinCrateSeconds += 150;
                    break;
            }
        }

        public void AddCharminarGate()
        {
            age++;
            switch (age)
            {
                case 2:
                    AddUnits(cUnit.Sowar, 2);
                    population += 4;
                    break;
                case 3:
                    AddUnits(cUnit.Mahout, 1);
                    population += 6;
                    break;
                case 4:
                    AddUnits(cUnit.Mahout, 2);
                    population += 12;
                    break;
            }
        }

        //Setup
        public override int FoodStart()
        {
            food = 350;
            wood = 100;
            coin = 30;
            AddVillager(10);
            AllocateVills(1, 0, 0);
            SwitchVills(Resource.Food, Resource.Wood, 7);
            populationCap = 20;
            xp = 270;
            export = 125;
            return 104;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {   
                food = 150;
                wood = 100;
                coin = 30;
                AddVillager(9);
                AllocateVills(1, 0, 0);
                SwitchVills(Resource.Food, Resource.Wood, 7);
                shipmentsAvailable = 1;
                populationCap = 20;
                xp = 0;
                export = 120;
                techBuildings.Add(new TradingPost());
                return 84;
            }
            else
            {
                food = 550;
                wood = 100;
                coin = 30;
                AddVillager(11);
                AllocateVills(1, 0, 0);
                SwitchVills(Resource.Food, Resource.Wood, 7);
                shipmentsAvailable = 1;
                populationCap = 20;
                xp = 20;
                export = 134;
                return 130;
            }
        }

        public override int CoinStart()
        {
            food = 380;
            wood = 100;
            coin = 130;
            AddVillager(11);
            AllocateVills(1, 0, 0);
            SwitchVills(Resource.Food, Resource.Wood, 7);
            shipmentsAvailable = 1;
            populationCap = 20;
            xp = 20;
            export = 134;
            return 130;
        }
    }
}
