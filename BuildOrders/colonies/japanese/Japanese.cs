using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Japanese : AsianColony
    {
        //Crates: 4f 2w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Japanese(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new JapaneseExplorer());
            explorers.Add(new JapaneseExplorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
            foodBaseGatherRate = .67;
        }
        public Japanese() { }

        public int shrinecount;
        public double cherryFood = 10000;
        public int militaryRicksjaws;
        public bool bank;
        
        public bool heavenlyKami;
        public bool toshoguShrine;
        public bool shogunate;
        public bool toriiGates;
        public bool tempoReforms;

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.Crates300w,
                cShipment.Vills2,
                cShipment.HeavenlyKami,
                cShipment.GoodFaithAgreements,
                cShipment.AdvancedDock,
                cShipment.EastIndiamen,

                //Colonial
                cShipment.Export300,
                cShipment.Vills4,
                cShipment.RenderingPlant,
                cShipment.Crates600w,
                cShipment.Crates600c,
                cShipment.Crates600f,
                cShipment.CherryOrchards,

                cShipment.Yumi5,
                cShipment.Ashigaru5,
                cShipment.DaimyoMototada,

                //Fortress
                cShipment.Vills7,
                cShipment.Crates1000c,
                cShipment.Crates1000w,
                cShipment.Crates1000f,

                cShipment.Yumi9,
                cShipment.Ashigaru8,
                cShipment.Naginata5,
                cShipment.FlamingArrow2,
                cShipment.DaimyoKiyomasa,
                cShipment.Intervention,

                //Industrial
                cShipment.Yumi16,
                cShipment.FlamingArrow4,
                cShipment.ShogunTokugawa,
            });
        }

        public JapaneseConsulate MyConsulate()
        {
            return (JapaneseConsulate)consulate;
        }

        public override void Income()
        {
            base.Income();
            GatherFromShrines();
            AllianceIncome();
            if (bank)
                coin += 2.75;
        }

        public override void Gather()
        {
            var foodgathered = foodBaseGatherRate * (double)foodGatherRateBonus * FoodGatherers().Count;
            food += foodgathered;
            cherryFood -= foodgathered;
            wood += woodBaseGatherRate * (double)woodGatherRateBonus * WoodGatherers().Count;
            coin += coinBaseGatherRate * (double)coinGatherRateBonus * CoinGatherers().Count;
        }

        public void AllianceIncome()
        {
            var alliance = MyConsulate().alliance;
            if (alliance == Alliance.Dutch)
                coin += .8;
            else if (alliance == Alliance.Spanish)
                xp += .8;
        }

        public void GatherFromShrines()
        {
            if (buildingsGathering == Resource.Default)
                buildingsGathering = Resource.Food;

            var shrinegatherrate = ShrineGatherRate();

            double resourcesgathered = 0;
            for (int i = 0; i < shrinecount; i++)
            {
                if (i < 15)
                {
                    if (i < 10)
                        resourcesgathered += shrinegatherrate + .28;
                    else
                        resourcesgathered += shrinegatherrate + .21;
                }
                else
                    resourcesgathered += shrinegatherrate + .07;
            }

            if (toshoguShrine)
                resourcesgathered += 1;

            switch (buildingsGathering)
            {
                case Resource.Food:
                    food += resourcesgathered;
                    break;
                case Resource.Wood:
                    wood += resourcesgathered;
                    break;
                case Resource.Coin:
                    coin += resourcesgathered;
                    break;
            }
        }

        public double ShrineGatherRate()
        {
            var baserate = .1;
            if (buildingsGathering == Resource.Food)
                baserate = .14;

            double gatherrate = baserate;
            if (heavenlyKami)
                gatherrate += baserate * 1.5;
            if (toshoguShrine)
                gatherrate += baserate * 1.5;
            if (tempoReforms)
            {
                if (buildingsGathering == Resource.Food)
                    gatherrate += baserate * 4.5;
                else
                    gatherrate += baserate * 4;
            }
            return gatherrate;
        }

        public override int GetCountByBuildingName(string name)
        {
            if (name == "shrine")
                return shrinecount;
            return base.GetCountByBuildingName(name);
        }

        //Add units
        public override void AddUnits(ConstUnit unit, int amount)
        {
            base.AddUnits(unit, amount);
            if (toriiGates)
                xp += .5 * unit.buildxp;
        }

        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new JapaneseVillager());
        }

        //Add buildings
        public override void AddBuilding(ConstBuilding building)
        {
            base.AddBuilding(building);
            if (toriiGates)
                xp += .5 * building.buildxp;
        }

        public override void AddTownCenter()
        {
            unitBuildings.Add(new JapaneseTownCenter());
            populationCap += 10;
        }

        public override void AddConsulate()
        {
            consulate = new JapaneseConsulate();
            unitBuildings.Add(consulate);
        }

        public void AddStable()
        {
            unitBuildings.Add(new JapaneseStable());
        }

        public void AddBarracks()
        {
            unitBuildings.Add(new JapaneseBarracks());
        }

        public void AddShrine()
        {
            shrinecount++;
            populationCap += 10;
        }

        public override void AddMarket()
        {
            techBuildings.Add(new JapaneseMarket());
        }

        public override void AddCastle()
        {
            unitBuildings.Add(new JapaneseCastle());
        }

        //Add techs
        public void AddAllyDutch()
        {
            MyConsulate().SetAllyDutch();
        }

        public void AddAllySpanish()
        {
            MyConsulate().SetAllySpanish();
        }

        public void AddAllyPortuguese()
        {
            MyConsulate().SetAllyPortuguese();
        }

        public void AddAllyJapanese()
        {
            MyConsulate().SetAllyJapanese();
        }

        public void AddPortugueseExpeditionaryCompany()
        {
            AddUnits(cUnit.BesteiroCrossbow, 7);
            population += 7;
        }

        public void AddPortugueseExpeditionaryForce()
        {
            AddUnits(cUnit.BesteiroCrossbow, 10);
            AddUnits(cUnit.Culverin, 1);
            population += 14;
        }

        public void AddFishingFleet()
        {
            AddFishingBoat(3);
            population += 3;
            consulate.allowedTechs.Remove(cTech.FishingFleet);
        }

        public void AddBankWagon()
        {
            bank = true;
            consulate.allowedTechs.Remove(cTech.BankWagon);
        }

        public void AddDutchExpeditionaryCompany()
        {
            AddUnits(cUnit.StadhouderMusketeer, 6);
            population += 6;
        }

        public void AddDutchExpeditionaryForce()
        {
            AddUnits(cUnit.StadhouderMusketeer, 6);
            AddUnits(cUnit.Carabineer, 6);
            population += 12;
        }

        public void AddSpanishExpeditionaryCompany()
        {
            AddUnits(cUnit.TercioPikeman, 7);
            population += 7;
        }

        public void AddSpanishExpeditionaryForce()
        {
            AddUnits(cUnit.TercioPikeman, 10);
            AddUnits(cUnit.Falconet, 1);
            population += 14;
        }

        //Add shipments
        public void AddVills2()
        {
            AddVillager(2);
        }

        public void AddHeavenlyKami()
        {
            heavenlyKami = true;
        }

        public void AddCherryOrchards()
        {
            cherryFood += 10000;
        }

        public void AddYumi5()
        {
            AddUnits(cUnit.Yumi, 5);
        }

        public void AddAshigaru5()
        {
            AddUnits(cUnit.Ashigaru, 5);
        }

        public void AddDaimyoMototada()
        {
            AddUnits(cUnit.DaimyoMototada, 1);
        }

        public void AddVills7()
        {
            AddVillager(7);
        }

        public void AddYumi9()
        {
            AddUnits(cUnit.Yumi, 9);
        }

        public void AddAshigaru8()
        {
            AddUnits(cUnit.Ashigaru, 8);
        }

        public void AddNaginata5()
        {
            AddUnits(cUnit.Naginata, 5);
        }

        public void AddFlamingArrow2()
        {
            AddUnits(cUnit.FlamingArrow, 2);
        }

        public void AddDaimyoKiyomasa()
        {
            AddUnits(cUnit.DaimyoKiyomasa, 1);
        }

        public void AddYumi16()
        {
            AddUnits(cUnit.Yumi, 16);
        }

        public void AddFlamingArrow4()
        {
            AddUnits(cUnit.FlamingArrow, 4);
        }

        public void AddShogunTokugawa()
        {
            AddUnits(cUnit.ShogunTokugawa, 1);
        }

        //Add wonders
        public void AddToshoguShrine()
        {
            age++;
            toshoguShrine = true;
            switch (age)
            {
                case 2:
                    export += 200;
                    break;
                case 3:
                    export += 400;
                    break;
                case 4:
                    export += 800;
                    break;
            }
        }

        public void AddGoldenPavilion()
        {
            age++;
            switch (age)
            {
                case 2:
                    AddUnits(cUnit.Yumi, 3);
                    population += 3;
                    break;
                case 3:
                    AddUnits(cUnit.Yumi, 6);
                    population += 6;
                    break;
                case 4:
                    AddUnits(cUnit.Yumi, 10);
                    population += 10;
                    break;
            }
        }

        public void AddShogunate()
        {
            age++;
            shogunate = true;
            switch (age)
            {
                case 2:
                    xp += 400;
                    break;
                case 3:
                    AddUnits(cUnit.DaimyoMasamune, 1);
                    population += 4;
                    xp += 300;
                    break;
                case 4:
                    AddUnits(cUnit.DaimyoMasamune, 1);
                    population += 4;
                    xp += 600;
                    break;
            }
        }

        public void AddToriiGates()
        {
            age++;
            militaryRicksjaws++;
            switch (age)
            {
                case 2:
                    AddUnits(cUnit.Samurai, 1);
                    population += 2;
                    break;
                case 3:
                    AddUnits(cUnit.Samurai, 3);
                    population += 6;
                    break;
                case 4:
                    AddUnits(cUnit.Samurai, 6);
                    population += 12;
                    break;
            }
        }

        //Setup
        public override int FoodStart()
        {
            food = 340;
            wood = 0;
            coin = 30;
            AddVillager(10);
            shipmentsAvailable = 1;
            populationCap = 20;
            xp = 27;
            export = 24;
            shrinecount = 1;
            AddConsulate();
            MyConsulate().SetAllyPortuguese();
            return 106;
        }

        public override int WoodStart(bool tpstart)
        {
            if (tpstart)
            {
                food = 460;
                wood = 0;
                coin = 30;
                AddVillager(9);
                shipmentsAvailable = 1;
                populationCap = 20;
                xp = 40;
                export = 118;
                shrinecount = 1;
                techBuildings.Add(new TradingPost());
                return 81;
            }
            else
            {
                food = 450;
                wood = 0;
                coin = 30;
                AddVillager(10);
                shipmentsAvailable = 1;
                populationCap = 20;
                xp = 27;
                export = 25;
                shrinecount = 1;
                AddConsulate();
                MyConsulate().SetAllyPortuguese();
                return 107;
            }
        }

        public override int CoinStart()
        {
            food = 310;
            wood = 0;
            coin = 130;
            AddVillager(10);
            shipmentsAvailable = 1;
            populationCap = 20;
            xp = 27;
            export = 25;
            shrinecount = 1;
            AddConsulate();
            MyConsulate().SetAllyPortuguese();
            return 107;
        }
    }
}
