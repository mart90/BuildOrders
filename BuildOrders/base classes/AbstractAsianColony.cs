using System;
using System.Linq;

namespace BuildOrders
{
    [Serializable]
    public abstract class AsianColony : Colony
    {
        public double export = 100;
        public bool export300;
        public bool goodFaithAgreements;
        public bool eastIndiamen;
        public Consulate consulate;

        public override void Income()
        {
            base.Income();
            export += (Gatherers().Count * 0.03);
        }

        public override double UnspentScore()
        {
            return food + wood + coin + export;
        }

        public override Villager GetVillager()
        { 
            if (FoodGatherers().Count + WoodGatherers().Count + CoinGatherers().Count == 0)
                return null;

            if (FoodGatherers().Count >= Math.Max(WoodGatherers().Count, CoinGatherers().Count))
                return FoodGatherers().Find(vill => !vill.constructing);
            else if (WoodGatherers().Count > CoinGatherers().Count)
                return WoodGatherers().Find(vill => !vill.constructing);
            else
                return CoinGatherers().Find(vill => !vill.constructing);
        }

        //Add buildings
        public abstract void AddConsulate();
        public abstract void AddCastle();

        public override void AddMarket()
        {
            techBuildings.Add(new AsianMarket());
        }

        public void AddDock()
        {
            unitBuildings.Add(new AsianDock());
        }

        //Add techs
        public void AddHuntingEagles()
        {
            foodGatherRateBonus += .05m;
            AddAllowedTech(cTech.HuntingEagles, cTech.ProfessionalHunters);
        }

        public void AddProfessionalHunters()
        {
            foodGatherRateBonus += .1m;
            RemoveAllowedTech(cTech.ProfessionalHunters);
        }

        public void AddHanamiParties()
        {
            foodGatherRateBonus += .05m;
            AddAllowedTech(cTech.HanamiParties, cTech.YozakuraLanterns);
        }

        public void AddYozakuraLanterns()
        {
            foodGatherRateBonus += .1m;
            RemoveAllowedTech(cTech.YozakuraLanterns);
        }

        public void AddWaterWheel()
        {
            woodGatherRateBonus += .05m;
            AddAllowedTech(cTech.WaterWheel, cTech.RegenerativeForestry);
        }

        public void AddRegenerativeForestry()
        {
            woodGatherRateBonus += .1m;
            AddAllowedTech(cTech.RegenerativeForestry, cTech.TimberTrade);
        }

        public void AddTimberTrade()
        {
            woodGatherRateBonus += .3m;
            RemoveAllowedTech(cTech.TimberTrade);
        }

        public void AddBlanketFilters()
        {
            coinGatherRateBonus += .05m;
            AddAllowedTech(cTech.BlanketFilters, cTech.FlumeAndDitching);
        }

        public void AddFlumeAndDitching()
        {
            coinGatherRateBonus += .1m;
            RemoveAllowedTech(cTech.FlumeAndDitching);
        }

        public void AddCivilServants()
        {
            foodGatherRateBonus += .05m;
            woodGatherRateBonus += .05m;
            coinGatherRateBonus += .05m;
            AddAllowedTech(cTech.CivilServants, cTech.ImperialBureaucracy);
        }

        public void AddImperialBureaucracy()
        {
            foodGatherRateBonus += .1m;
            woodGatherRateBonus += .1m;
            coinGatherRateBonus += .1m;
            RemoveAllowedTech(cTech.ImperialBureaucracy);
        }

        public virtual void AddCancelAlliance()
        {
            consulate.SetNoAlliance();
        }

        public void AddCrates500w()
        {
            woodCrateSeconds += 30;
            consulate.allowedTechs.Remove(cTech.Crates500w);
        }

        public void AddCrates500c()
        {
            coinCrateSeconds += 30;
            consulate.allowedTechs.Remove(cTech.Crates500c);
        }

        public void AddCrates500f()
        {
            foodCrateSeconds += 30;
            consulate.allowedTechs.Remove(cTech.Crates500f);
        }

        public void AddBritishExpeditionaryCompany()
        {
            AddUnits(cUnit.RedcoatMusketeer, 6);
            population += 6;
        }

        public void AddBritishExpeditionaryForce()
        {
            AddUnits(cUnit.RedcoatMusketeer, 8);
            AddUnits(cUnit.Falconet, 1);
            population += 12;
        }

        //Add shipments
        public void AddExport300()
        {
            export += 300;
            export300 = true;
        }

        public void AddGoodFaithAgreements()
        {
            goodFaithAgreements = true;
        }

        public void AddEastIndiamen()
        {
            unitBuildings.Add(new AsianDock());
            eastIndiamen = true;
        }

        public void AddIntervention()
        {
            switch (consulate.alliance)
            {
                case Alliance.British:
                    AddUnits(cUnit.RedcoatMusketeer, 9);
                    population += 9;
                    break;
                case Alliance.Ottomans:
                    AddUnits(cUnit.GardenerHussar, 4);
                    population += 8;
                    break;
                case Alliance.French:
                    AddUnits(cUnit.YoungGardeGrenadier, 5);
                    population += 10;
                    break;
                case Alliance.Portuguese:
                    AddUnits(cUnit.BesteiroCrossbow, 11);
                    population += 11;
                    break;
                case Alliance.Dutch:
                    AddUnits(cUnit.StadhouderMusketeer, 9);
                    population += 9;
                    break;
                case Alliance.Germans:
                    AddUnits(cUnit.ZweihanderDoppelsoldner, 4);
                    population += 8;
                    break;
                case Alliance.Russians:
                    AddUnits(cUnit.SiberianCossack, 6);
                    population += 6;
                    break;
                case Alliance.Japanese:
                    AddUnits(cUnit.KonshaYamabushi, 10);
                    population += 10;
                    break;
                case Alliance.Spanish:
                    AddUnits(cUnit.TercioPikeman, 11);
                    population += 11;
                    break;

                default:
                    break;
            }
        }
    }
}
