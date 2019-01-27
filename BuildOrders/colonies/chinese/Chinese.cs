using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Chinese : AsianColony
    {
        // Crates: 2f 3w

        public Chinese(bool tpstart)
        {
            randomCrate = Resource.Wood;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count;
            SetAllowedShipments();
        }
        public Chinese() { }

        public int porcelainTowerMultiplier;
        public bool oldHanReforms;
        public int villagecount;

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.NorthernRefugees,
                cShipment.Crates300w,
                cShipment.GoodFaithAgreements,
                cShipment.AdvancedDock,
                cShipment.EastIndiamen,

                //Colonial
                cShipment.RenderingPlant,
                cShipment.Crates700c,
                cShipment.Crates700w,
                cShipment.Crates600c,
                cShipment.Crates600w,
                cShipment.Crates700f,
                cShipment.SpiceTrade,

                cShipment.ChuKoNu8,
                cShipment.QiangPikeman9,
                cShipment.SteppeRider7,

                //Fortress
                cShipment.Crates1000w,
                cShipment.Crates1000c,
                cShipment.Crates1000f,

                cShipment.ChuKoNu13,
                cShipment.Arquebusier10,
                cShipment.ChangdaoSwordsman11,
                cShipment.MeteorHammer5,
                cShipment.IronFlail4,
                cShipment.HandMortar7,
                cShipment.Intervention,
                cShipment.Manchu9,

                //Industrial
                cShipment.OldHanReforms,
                cShipment.Crates1600w,
                cShipment.Crates1600c,

                cShipment.ChuKoNu21,
                cShipment.QiangPikeman21,
                cShipment.MeteorHammer8,
                cShipment.FlyingCrow2,
            });
        }

        public ChineseConsulate MyConsulate()
        {
            return (ChineseConsulate)consulate;
        }

        public override void Income()
        {
            base.Income();

            if (porcelainTowerMultiplier > 0)
            {
                if (buildingsGathering == Resource.Food)
                    food += 1.5 + porcelainTowerMultiplier * 1.5;
                if (buildingsGathering == Resource.Wood)
                    wood += 1 + porcelainTowerMultiplier * 1.5;
                if (buildingsGathering == Resource.Coin)
                    coin += 1 + porcelainTowerMultiplier * 1.5;
            }
        }

        public override int GetCountByBuildingName(string name)
        {
            if (name == "village")
                return villagecount;
            return base.GetCountByBuildingName(name);
        }

        public override void UpdateQueues()
        {
            var sp = unitBuildings.Find(building => building.commonName == "SummerPalace");
            if (sp != null && sp.timer <= 0)
            {
                if (sp.unitQueued == cUnit.OldHanArmy)
                    population += 6;
                else if (sp.unitQueued == cUnit.ForbiddenArmy)
                    population += 8;
            }

            var ca = unitBuildings.Find(building => building.commonName == "ConfucianAcademy");
            if (ca != null && sp.timer == 0)
                population += 7;

            base.UpdateQueues();
        }

        //Unit counts
        public override int GetCountByUnitName(string name)
        {
            switch (name)
            {
                case "chukonu":
                    return ChuKoNuCount();
                case "stepperider":
                    return SteppeRiderCount();
                case "qiangpikeman":
                    return QiangPikemanCount();
                case "keshik":
                    return KeshikCount();
                case "arquebusier":
                    return ArquebusierCount();
                case "changdaoswordsman":
                    return ChangdaoSwordsmanCount();
                case "meteorhammer":
                    return MeteorHammerCount();
                case "ironflail":
                    return IronFlailCount();

                default:
                    return base.GetCountByUnitName(name);
            }
        }

        public int ChuKoNuCount()
        {
            var ckn = militaryUnits.FindAll(unit => unit.name == "ChuKoNu").Count;
            ckn += militaryUnits.FindAll(unit => unit.name == "OldHanArmy").Count * 3;
            ckn += militaryUnits.FindAll(unit => unit.name == "StandardArmy").Count * 3;
            return ckn;
        }

        public int SteppeRiderCount()
        {
            var steppes = militaryUnits.FindAll(unit => unit.name == "SteppeRider").Count;
            steppes += militaryUnits.FindAll(unit => unit.name == "StandardArmy").Count * 2;
            return steppes;
        }

        public int QiangPikemanCount()
        {
            var pikes = militaryUnits.FindAll(unit => unit.name == "QiangPikeman").Count;
            pikes += militaryUnits.FindAll(unit => unit.name == "OldHanArmy").Count * 3;
            pikes += militaryUnits.FindAll(unit => unit.name == "MingArmy").Count * 3;
            return pikes;
        }

        public int KeshikCount()
        {
            var keshik = militaryUnits.FindAll(unit => unit.name == "Keshik").Count;
            keshik += militaryUnits.FindAll(unit => unit.name == "MingArmy").Count * 2;
            return keshik;
        }

        public int ArquebusierCount()
        {
            var arqs = militaryUnits.FindAll(unit => unit.name == "Arquebusier").Count;
            arqs += militaryUnits.FindAll(unit => unit.name == "TerritorialArmy").Count * 3;
            arqs += militaryUnits.FindAll(unit => unit.name == "ImperialArmy").Count * 3;
            return arqs;
        }

        public int ChangdaoSwordsmanCount()
        {
            var changdao = militaryUnits.FindAll(unit => unit.name == "ChangdaoSwordsman").Count;
            changdao += militaryUnits.FindAll(unit => unit.name == "TerritorialArmy").Count * 3;
            return changdao;
        }

        public int MeteorHammerCount()
        {
            var meteors = militaryUnits.FindAll(unit => unit.name == "MeteorHammer").Count;
            meteors += militaryUnits.FindAll(unit => unit.name == "ForbiddenArmy").Count * 2;
            return meteors;
        }

        public int IronFlailCount()
        {
            var flails = militaryUnits.FindAll(unit => unit.name == "IronFlail").Count;
            flails += militaryUnits.FindAll(unit => unit.name == "ForbiddenArmy").Count * 2;
            flails += militaryUnits.FindAll(unit => unit.name == "ImperialArmy").Count * 2;
            return flails;
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new ChineseVillager());
        }

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new ChineseTownCenter());
            populationCap += 10;
        }

        public override void AddConsulate()
        {
            consulate = new ChineseConsulate();
            unitBuildings.Add(consulate);
        }

        public void AddWarAcademy()
        {
            unitBuildings.Add(new WarAcademy());
        }

        public void AddVillage()
        {
            populationCap += 20;
            villagecount++;
        }

        public override void AddCastle()
        {
            unitBuildings.Add(new ChineseCastle());
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

        public void AddAllyFrench()
        {
            MyConsulate().SetAllyFrench();
        }

        public void AddAllyGermans()
        {
            MyConsulate().SetAllyGermans();
        }

        public void AddAllyRussians()
        {
            MyConsulate().SetAllyRussians();
        }

        public void AddAllyBritish()
        {
            MyConsulate().SetAllyBritish();
        }

        public void AddRussianExpeditionaryCompany()
        {
            AddUnits(cUnit.SiberianCossack, 4);
            population += 4;
        }

        public void AddRussianExpeditionaryForce()
        {
            AddUnits(cUnit.SiberianCossack, 5);
            AddUnits(cUnit.Culverin, 1);
            population += 9;
        }

        public void AddGermanExpeditionaryCompany()
        {
            AddUnits(cUnit.ZweihanderDoppelsoldner, 3);
            population += 6;
        }

        public void AddGermanExpeditionaryForce()
        {
            AddUnits(cUnit.ZweihanderDoppelsoldner, 3);
            AddUnits(cUnit.PrussianNeedleGun, 6);
            population += 12;
        }

        //Add shipments
        public void AddNorthernRefugees()
        {
            var villstoadd = villagecount + FindBuildingsByName("TownCenter").Count;
            AddVillager(villstoadd);
            population += villstoadd;
        }

        public void AddChuKoNu8()
        {
            AddUnits(cUnit.ChuKoNu, 8);
        }

        public void AddQiangPikeman9()
        {
            AddUnits(cUnit.QiangPikeman, 9);
        }

        public void AddSteppeRider7()
        {
            AddUnits(cUnit.SteppeRider, 7);
        }

        public void AddChuKoNu13()
        {
            AddUnits(cUnit.ChuKoNu, 13);
        }

        public void AddArquebusier10()
        {
            AddUnits(cUnit.Arquebusier, 10);
        }

        public void AddChangdaoSwordsman11()
        {
            AddUnits(cUnit.ChangdaoSwordsman, 11);
        }

        public void AddMeteorHammer5()
        {
            AddUnits(cUnit.MeteorHammer, 5);
        }

        public void AddIronFlail4()
        {
            AddUnits(cUnit.IronFlail, 4);
        }

        public void AddHandMortar7()
        {
            AddUnits(cUnit.HandMortar, 7);
        }

        public void AddOldHanReforms()
        {
            oldHanReforms = true;
        }

        public void AddChuKoNu21()
        {
            AddUnits(cUnit.ChuKoNu, 13);
        }

        public void AddQiangPikeman21()
        {
            AddUnits(cUnit.QiangPikeman, 9);
        }

        public void AddMeteorHammer8()
        {
            AddUnits(cUnit.MeteorHammer, 5);
        }

        public void AddFlyingCrow2()
        {
            AddUnits(cUnit.FlyingCrow, 2);
        }

        //Add wonders
        public void AddPorcelainTower()
        {
            porcelainTowerMultiplier = age;
            age++;
            buildingsGathering = Resource.Wood;
        }

        public void AddWhitePagoda()
        {
            age++;
            switch (age)
            {
                case 2:
                    AddUnits(cUnit.Disciple, 4);
                    break;
                case 3:
                    AddUnits(cUnit.Disciple, 6);
                    break;
                case 4:
                    AddUnits(cUnit.Disciple, 10);
                    break;
            }
        }

        public void AddSummerPalace()
        {
            age++;
            var sp = new SummerPalace();
            switch (age)
            {
                case 2:
                    sp.MakeOldHanArmy();
                    foodCrateSeconds += 40;
                    break;
                case 3:
                    sp.MakeForbiddenArmy();
                    foodCrateSeconds += 100;
                    break;
                case 4:
                    sp.MakeForbiddenArmy();
                    foodCrateSeconds += 150;
                    break;
            }
            queuesToUpdate.Add(sp);
            unitBuildings.Add(sp);
        }

        public void AddConfucianAcademy()
        {
            age++;
            var ca = new ConfucianAcademy();
            switch (age)
            {
                case 2:
                    AddUnits(cUnit.ChuKoNu, 4);
                    population += 4;
                    break;
                case 3:
                    AddUnits(cUnit.Arquebusier, 8);
                    population += 8;
                    break;
                case 4:
                    AddUnits(cUnit.Arquebusier, 12);
                    population += 12;
                    break;
            }
            ca.MakeFlyingCrow();
            queuesToUpdate.Add(ca);
            unitBuildings.Add(ca);
        }

        public void AddTempleOfHeaven()
        {
            age++;
            switch (age)
            {
                case 2:
                    AddVillager(3);
                    population += 3;
                    break;
                case 3:
                    AddVillager(6);
                    population += 6;
                    break;
                case 4:
                    AddVillager(10);
                    population += 10;
                    break;
            }
        }

        //Setup
        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 115;
                wood = 200;
                coin = 30;
                AddVillager(9);
                populationCap = 10;
                xp = 10;
                shipmentsAvailable = 1;
                techBuildings.Add(new TradingPost());
                return 82;
            }
            else
            {
                food = 170;
                wood = 0;
                coin = 30;
                AddVillager(10);
                villagecount = 2;
                populationCap = 50;
                xp = 30;
                shipmentsAvailable = 1;
                return 106;
            }
        }

        public override int FoodStart()
        {
            return 0;
        }

        public override int CoinStart()
        {
            return 0;
        }
    }
}
