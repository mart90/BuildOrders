using System;

namespace BuildOrders
{
    [Serializable]
    public abstract class NativeColonyBuilder : ColonyBuilder
    {
        public override bool MakeBuilding(ConstBuilding building, int numvills = 1)
        {
            if (building.name == "FirePit" && ((NativeColony)colony).firePit != null)
                return false;

            return base.MakeBuilding(building, numvills);
        }

        public override bool MakeTech(ConstTech tech)
        {
            if (tech != cTech.WiseWoman
                && tech != cTech.Messenger
                && tech != cTech.Chief
                && tech != cTech.Warrior
                && tech != cTech.Shaman)
                return base.MakeTech(tech);

            tech = tech.DeepCopy();
            switch (colony.age)
            {
                case 1:
                    tech.foodcost = 800;
                    break;
                case 2:
                    tech.foodcost = 1200;
                    tech.coincost = 1000;
                    tech.traintime = 110;
                    break;
                case 3:
                    tech.foodcost = 2000;
                    tech.coincost = 1200;
                    break;
            }

            if (tech.name == "Messenger")
            {
                if (colony.age == 2)
                    tech.traintime = 40;
                else
                    tech.traintime = 30;
            }

            return base.MakeTech(tech);
        }

        public void AddDancers(int amount)
        {
            var fp = ((NativeColony)colony).firePit;
            Villager vill;
            if (amount >= 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    vill = colony.GetVillager();
                    vill.resourceGathering = Resource.Default;
                    fp.dancingVillagers.Add(vill);
                }
            }
            else
            {
                for (int i = 0; i > amount; i--)
                {
                    vill = fp.dancingVillagers[0];
                    vill.idle = true;
                    fp.dancingVillagers.RemoveAt(0);
                }
            }
        }
    }
}
