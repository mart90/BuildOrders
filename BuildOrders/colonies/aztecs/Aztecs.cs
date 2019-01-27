using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Aztecs : NativeColony
    {
        //Crates: 3f 2w +
        // - 1f (20%)
        // - 1c (40%) + 1f (50%)
        // - 1w (40%) + 1f (50%)

        public Aztecs(Resource randomcrate, bool tpstart)
        {
            randomCrate = randomcrate;
            techBuildings.Add(new HomeCity());
            explorers.Add(new Explorer());
            startTime = Setup(tpstart);
            population = villagers.Count + 1;
            SetAllowedShipments();
        }
        public Aztecs() { }

        public int warriorPriests = 1;

        public override void SetAllowedShipments()
        {
            allowedShipments.AddRange(new List<ConstShipment>
            {
                //Discovery
                cShipment.Vills3,
                cShipment.Crates300w,
                cShipment.AdvancedDock,
                cShipment.Schooners,
                
                //Colonial
                cShipment.Vills4,
                cShipment.Vills5,
                cShipment.WarriorPriest3,
                cShipment.Crates600c,
                cShipment.Crates700w,
                cShipment.Crates600w,

                cShipment.PumaSpearman6,
                cShipment.Macehualtin10,
                cShipment.Macehualtin9,
                cShipment.CoyoteRunner5,

                //Fortress
                cShipment.Vills8,
                cShipment.Crates1000w,
                cShipment.Crates800c,

                cShipment.CoyoteRunner10,
                cShipment.Macehualtin13,
                cShipment.EagleRunnerKnight5,
                cShipment.EagleRunnerKnight6,
                cShipment.JaguarProwlKnight5,
                cShipment.JaguarProwlKnight6,
                cShipment.ArrowKnight6,
                cShipment.TempleOfCenteotl,
                cShipment.TempleOfTlaloc,
                cShipment.SkullKnight4,

                //Industrial
                cShipment.Macehualtin24,
                cShipment.Macehualtin20,
                cShipment.CoyoteRunner15,
                cShipment.SkullKnight7,
            });
        }

        public AztecFirePit MyFirePit()
        {
            return firePit == null ? null : (AztecFirePit)firePit;
        }

        public override void FirePitActions()
        {
            var fp = MyFirePit();
            var dancers = fp.dancingVillagers.Count + 2 * warriorPriests;

            if (fp.dance == Dance.Gift)
                xp += .5 * dancers;
            else if (fp.dance == Dance.Holy)
            {
                fp.danceTimer -= 1 + dancers;
                if (fp.danceTimer <= 0)
                {
                    fp.danceTimer = 400;
                    warriorPriests++;
                }
            }
            else if (fp.dance == Dance.Fertility)
                FertilityDance(dancers);
        }

        //Add units
        public override void AddVillager(int amount = 1)
        {
            for (int i = 0; i < amount; i++)
                villagers.Add(new AztecVillager());
        }

        //Add buildings
        public override void AddTownCenter()
        {
            unitBuildings.Add(new AztecTownCenter());
            populationCap += 10;
        }

        public override void AddFirePit()
        {
            firePit = new AztecFirePit();
        }

        public override void AddWarHut()
        {
            unitBuildings.Add(new AztecWarHut());
        }

        public void AddNoblesHut()
        {
            unitBuildings.Add(new NoblesHut());
        }

        //Add techs

        //Add shipments
        public void AddWarriorPriest3()
        {
            warriorPriests += 3;
        }

        public void AddPumaSpearman6()
        {
            AddUnits(cUnit.PumaSpearman, 6);
        }

        public void AddMacehualtin10()
        {
            AddUnits(cUnit.Macehualtin, 10);
        }

        public void AddMacehualtin9()
        {
            AddUnits(cUnit.Macehualtin, 9);
        }

        public void AddCoyoteRunner5()
        {
            AddUnits(cUnit.CoyoteRunner, 5);
        }

        public void AddCrates800c()
        {
            coinCrateSeconds += 80;
        }

        public void AddCoyoteRunner10()
        {
            AddUnits(cUnit.CoyoteRunner, 10);
        }

        public void AddMacehualtin13()
        {
            AddUnits(cUnit.Macehualtin, 13);
        }

        public void AddEagleRunnerKnight5()
        {
            AddUnits(cUnit.EagleRunnerKnight, 5);
        }

        public void AddEagleRunnerKnight6()
        {
            AddUnits(cUnit.EagleRunnerKnight, 6);
        }

        public void AddArrowKnight6()
        {
            AddUnits(cUnit.ArrowKnight, 6);
        }

        public void AddJaguarProwlKnight5()
        {
            AddUnits(cUnit.JaguarProwlKnight, 5);
        }

        public void AddJaguarProwlKnight6()
        {
            AddUnits(cUnit.JaguarProwlKnight, 6);
        }

        public void AddSkullKnight4()
        {
            AddUnits(cUnit.SkullKnight, 4);
        }

        public void AddTempleOfCenteotl()
        {
            AddUnits(cUnit.Macehualtin, 18);
        }

        public void AddTempleOfTlaloc()
        {
            AddUnits(cUnit.EagleRunnerKnight, 8);
        }

        public void AddMacehualtin24()
        {
            AddUnits(cUnit.Macehualtin, 24);
        }

        public void AddMacehualtin20()
        {
            AddUnits(cUnit.Macehualtin, 20);
        }

        public void AddCoyoteRunner15()
        {
            AddUnits(cUnit.CoyoteRunner, 15);
        }

        public void AddSkullKnight7()
        {
            AddUnits(cUnit.SkullKnight, 7);
        }

        //Add politicians
        public override void AddWiseWoman()
        {
            age++;
        }

        public override void AddChief()
        {
            age++;
        }

        public override void AddMessenger()
        {
            age++;
        }

        public override void AddWarrior()
        {
            age++;
            var skullstoadd = 0;
            switch (age)
            {
                case 2:
                    skullstoadd = 2;
                    break;
                case 3:
                    skullstoadd = 3;
                    break;
                case 4:
                    skullstoadd = 5;
                    break;
            }

            AddUnits(cUnit.SkullKnight, skullstoadd);
            population += skullstoadd * 2;
        }

        public override void AddShaman()
        {
            age++;
            switch (age)
            {
                case 2:
                    MakeBuildingFromWagon(cBuilding.WarHut, 30);
                    break;
                case 3:
                    MakeBuildingFromWagon(cBuilding.NoblesHut, 30);
                    break;
                case 4:
                    MakeBuildingFromWagon(cBuilding.NoblesHut, 30);
                    MakeBuildingFromWagon(cBuilding.NoblesHut, 30);
                    break;
            }
        }

        //Setup
        public override int FoodStart()
        {
            food = 380;
            wood = 0;
            coin = 30;
            AddVillager(8);
            populationCap = 20;
            xp = 275;

            firePit = new AztecFirePit();
            warriorPriests = 1;
            MyFirePit().dance = Dance.Gift;

            return 81;
        }

        public override int WoodStart(bool tpstart = false)
        {
            if (tpstart)
            {
                food = 159;
                wood = 100;
                coin = 30;
                AddVillager(8);
                populationCap = 10;
                techBuildings.Add(new TradingPost());
                shipmentsAvailable = 1;
                xp = 90;

                firePit = new AztecFirePit();
                warriorPriests = 1;
                MyFirePit().dance = Dance.Fertility;

                return 81;
            }
            else
            {
                food = 290;
                wood = 0;
                coin = 0;
                AddVillager(9);
                populationCap = 20;
                shipmentsAvailable = 1;
                xp = 80;
                techBuildings.Add(new NativeMarket());
                AddHuntingDogs();
                RemoveAllowedTech(cTech.HuntingDogs);

                firePit = new AztecFirePit();
                warriorPriests = 1;
                MyFirePit().dance = Dance.Fertility;

                return 106;
            }
        }

        public override int CoinStart()
        {
            food = 330;
            wood = 0;
            coin = 130;
            AddVillager(8);
            populationCap = 20;
            xp = 275;

            firePit = new AztecFirePit();
            warriorPriests = 1;
            MyFirePit().dance = Dance.Gift;

            return 81;
        }
    }
}
