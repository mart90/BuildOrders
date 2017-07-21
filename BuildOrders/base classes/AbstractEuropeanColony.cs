using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public abstract class EuropeanColony : Colony
    {
        public decimal factoryFoodGatherRateBonus = 1.0m;
        public decimal factoryWoodGatherRateBonus = 1.0m;
        public decimal factoryCoinGatherRateBonus = 1.0m;
        public bool factoryMassProduction;

        public bool atp;

        public override void Income()
        {
            base.Income();
            if (age >= 4)
                FactoryActions();
        }

        public void FactoryActions()
        {
            var factories = FindFactories();
            if (factories.Count == 0)
                return;
            if (buildingsGathering == Resource.Default)
            {
                foreach (Factory factory in factories)
                    factory.unitProduction = true;
            }
            if (((Factory)factories[0]).unitProduction)
                FactoriesMakeUnit(factories);
            else if (buildingsGathering == Resource.Food)
                food += 5.5 * factories.Count * (double)factoryFoodGatherRateBonus;
            else if (buildingsGathering == Resource.Wood)
                wood += 5.5 * factories.Count * (double)factoryWoodGatherRateBonus;
            else if (buildingsGathering == Resource.Coin)
                coin += 5.5 * factories.Count * (double)factoryCoinGatherRateBonus;
        }

        public virtual List<UnitBuilding> FindFactories()
        {
            return FindBuildingsByUnit(cUnit.HeavyCannon);
        }

        public virtual void FactoriesMakeUnit(List<UnitBuilding> factories)
        {
            foreach (Factory factory in factories)
            {
                if (factory.unitQueued == null)
                {
                    factory.unitQueued = cUnit.HeavyCannon;
                    factory.unitsQueued = 1;
                    if (factoryMassProduction)
                        factory.timer = 86;
                    else
                        factory.timer = 115;
                    queuesToUpdate.Add(factory);
                }
            }
        }

        public override void AddUnits(ConstUnit unit, int amount)
        {
            base.AddUnits(unit, amount);
            if (unit == cUnit.HeavyCannon && amount == 1)
                population += 7;
        }

        //Add buildings
        public override void AddMarket()
        {
            techBuildings.Add(new EuropeanMarket());
        }

        public virtual void AddArtilleryFoundry()
        {
            unitBuildings.Add(new ArtilleryFoundry());
        }

        //Add techs
        public void AddHuntingDogs()
        {
            foodGatherRateBonus += .1m;
            AddAllowedTech(cTech.HuntingDogs, cTech.SteelTraps);
        }      
              
        public void AddSteelTraps()
        {
            foodGatherRateBonus += .2m;
        }      
               
        public void AddGangSaw()
        {
            woodGatherRateBonus += .1m;
            AddAllowedTech(cTech.GangSaw, cTech.LogFlume);
        }      
               
        public void AddLogFlume()
        {
            woodGatherRateBonus += .2m;
            AddAllowedTech(cTech.LogFlume, cTech.CircularSaw);
        }      
               
        public void AddCircularSaw()
        {
            woodGatherRateBonus += .3m;
        }      
               
        public void AddPlacerMines()
        {
            coinGatherRateBonus += .1m;
            AddAllowedTech(cTech.PlacerMines, cTech.Amalgamation);
        }      
               
        public void AddAmalgamation()
        {
            coinGatherRateBonus += .2m;
        }
        
        public void AddVeteranHussar()
        {
            foreach (Building stable in FindBuildingsByTech(cTech.VeteranHussar))
                ;
                //TODO
        }

        public void AddCannery()
        {
            factoryFoodGatherRateBonus += .3m;
        }

        public void AddWaterPower()
        {
            factoryWoodGatherRateBonus += .3m;
        }

        public void AddSteamPower()
        {
            factoryCoinGatherRateBonus += .3m;
        }

        public virtual void AddMassProduction()
        {
            cUnit.HeavyCannon.traintime = 86;
        }

        //Add shipments
        public void AddAdvancedTradingPost()
        {
            atp = true;
        }

        public void AddEconomicTheory()
        {
            foodGatherRateBonus += .1m;
            woodGatherRateBonus += .1m;
            coinGatherRateBonus += .1m;
        }

        public void AddMusketeer6()
        {
            AddUnits(cUnit.Musketeer, 6);
        }

        public void AddCrossbowman8()
        {
            AddUnits(cUnit.Crossbowman, 8);
        }

        public void AddHussar3()
        {
            AddUnits(cUnit.Hussar, 3);
        }

        public void AddSkirmisher8()
        {
            AddUnits(cUnit.Skirmisher, 8);
        }

        public void AddSkirmisher7()
        {
            AddUnits(cUnit.Skirmisher, 7);
        }

        public void AddDragoon5()
        {
            AddUnits(cUnit.Dragoon, 5);
        }

        public void AddCavalryArcher5()
        {
            AddUnits(cUnit.CavalryArcher, 5);
        }

        public void AddHussar5()
        {
            AddUnits(cUnit.Hussar, 5);
        }

        public void AddHussar4()
        {
            AddUnits(cUnit.Hussar, 4);
        }

        public void AddPikeman10()
        {
            AddUnits(cUnit.Pikeman, 10);
        }

        public void AddMusketeer9()
        {
            AddUnits(cUnit.Musketeer, 9);
        }

        public void AddFalconet2()
        {
            AddUnits(cUnit.Falconet, 2);
        }

        public virtual void AddFactory()
        {
            unitBuildings.Add(new Factory());
        }

        public virtual void AddRobberBarons()
        {
            unitBuildings.Add(new Factory());
        }

        public void AddHeavyCannon2()
        {
            AddUnits(cUnit.HeavyCannon, 2);
        }

        public void AddCavalryArcher9()
        {
            AddUnits(cUnit.CavalryArcher, 9);
        }

        //Add politicians
        public void AddPhilosophersPrince()
        {
            age = 2;
            foodCrateSeconds += 50;
        }

        public virtual void AddBishop()
        {
            age = 2;
            AddVillager(2);
            population += 2;
        }

        public void AddGovernor()
        {
            age = 2;
            coinCrateSeconds += 20;
        }

        public void AddQuartermaster()
        {
            age = 2;
            woodCrateSeconds += 40;
        }

        public virtual void AddMarksman()
        {
            age = 3;
            AddUnits(cUnit.Skirmisher, 6);
            population += 6;
        }

        public void AddExilePrince()
        {
            age = 3;
        }

        public void AddAdmiralOfOcean()
        {
            age = 3;
            woodCrateSeconds += 40;
        }

        public virtual void AddScout()
        {
            age = 3;
            AddUnits(cUnit.Hussar, 4);
            population += 8;
        }

        public void AddTycoon()
        {
            age = 4;
            coinCrateSeconds += 100;
        }

        public virtual void AddKingsMusketeer()
        {
            age = 4;
            AddUnits(cUnit.Musketeer, 10);
            population += 10;
        }

        public virtual void AddEngineer()
        {
            age = 4;
            AddUnits(cUnit.Falconet, 2);
            population += 8;
        }
    }
}
