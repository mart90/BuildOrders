using System;
using System.Linq;

namespace BuildOrders
{
    [Serializable]
    public abstract class NativeColony : Colony
    {
        public FirePit firePit;

        public override void Income()
        {
            base.Income();
            if (firePit != null)
                FirePitActions();
        }

        public virtual void FirePitActions()
        {
            var dancers = firePit.dancingVillagers.Count;

            if (firePit.dance == Dance.Gift)
                xp += .5 * dancers;
            else if (firePit.dance == Dance.Fertility)
                FertilityDance(dancers);
        }

        public void FertilityDance(int dancercount)
        {
            foreach (UnitBuilding building in queuesToUpdate.OfType<UnitBuilding>())
            {
                if (building.unitQueued != null)
                    building.timer -= 1 + dancercount * 0.09;
            }
        }

        //Add buildings
        public abstract void AddFirePit();
        public abstract void AddWarHut();

        public override void AddMarket()
        {
            techBuildings.Add(new NativeMarket());
        }
        public void AddDock()
        {
            unitBuildings.Add(new NativeDock());
        }

        //Add techs
        public void AddHuntingDogs()
        {
            foodGatherRateBonus += .1m;
            RemoveAllowedTech(cTech.HuntingDogs);
        }

        public void AddLumberCeremony()
        {
            woodGatherRateBonus += .2m;
            AddAllowedTech(cTech.LumberCeremony, cTech.ForestPeopleCeremony);
        }

        public void AddForestPeopleCeremony()
        {
            woodGatherRateBonus += .2m;
            AddAllowedTech(cTech.ForestPeopleCeremony, cTech.ForestSpiritCeremony);
        }

        public void AddForestSpiritCeremony()
        {
            woodGatherRateBonus += .2m;
            RemoveAllowedTech(cTech.ForestSpiritCeremony);
        }

        public void AddPlacerMines()
        {
            coinGatherRateBonus += .1m;
            RemoveAllowedTech(cTech.PlacerMines);
        }

        public void AddGillNets()
        {
            fishGatherRateBonus += .15m;
            whaleGatherRateBonus += .15m;
        }

        public void AddLongLines()
        {
            fishGatherRateBonus += .2m;
            whaleGatherRateBonus += .2m;
        }

        //Add politicians
        public abstract void AddWiseWoman();
        public abstract void AddWarrior();
        public abstract void AddShaman();
        public abstract void AddMessenger();
        public abstract void AddChief();
    }
}
