using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public abstract class AsianColonyBuilder : ColonyBuilder
    {
        public List<Villager> villsOnWonder = new List<Villager>();

        public bool MakeExportTech(ConstTech tech)
        {
            var exportcost = tech.exportcost;
            var traintime = tech.traintime;
            var asiancolony = (AsianColony)colony;

            if (tech.name.StartsWith("Ally") && asiancolony.export300)
                exportcost = 25;
            else if (asiancolony.goodFaithAgreements)
            {
                exportcost = Convert.ToInt32(tech.exportcost * .6);
                traintime = Convert.ToInt32(tech.traintime * .5);
            }

            if (asiancolony.age < tech.ageavailable
                || asiancolony.consulate == null
                || asiancolony.export < exportcost)
                return false;

            asiancolony.export -= exportcost;
            asiancolony.consulate.MakeTech(tech, traintime);
            asiancolony.queuesToUpdate.Add(asiancolony.consulate);

            if (!tech.name.Contains("Expeditionary"))
                asiancolony.RemoveAllowedTech(tech);

            return true;
        }

        public void SetWonderBuildersIdle()
        {
            foreach (Villager vill in villsOnWonder)
            {
                vill.ClearQueue();
            }
            villsOnWonder.Clear();
        }

        public bool MakeWonder(ConstBuilding wonder, int numberofvillagers = 1)
        {
            wonder = wonder.DeepCopy();

            switch (colony.age)
            {
                case 1:
                    wonder.foodcost = 800;
                    wonder.coincost = 0;
                    wonder.buildtime = 120;
                    break;
                case 2:
                    wonder.foodcost = 1200;
                    wonder.coincost = 800;
                    wonder.buildtime = 145;
                    break;
                case 3:
                    wonder.foodcost = 2000;
                    wonder.coincost = 1200;
                    wonder.buildtime = 120;
                    break;
            }

            wonder.buildtime -= numberofvillagers * 10;
            if (numberofvillagers > 4)
            {
                wonder.buildtime += (numberofvillagers - 4) * 5;
            }

            if (MakeBuilding(wonder))
            {
                if (numberofvillagers == 0)
                {
                    var wondervill = colony.villagers.Find(v => v.buildingQueued.name == wonder.name);
                    wondervill.idle = true;
                }
                
                for (var i = 0; i < numberofvillagers - 1; i++)
                    VillagerMakeBuilding(new ConstBuilding("Dummy", 0, 0, 0, wonder.buildtime, 0, 0));

                return true;
            }
            return false;
        }

        public override bool MakeUnit(ConstUnit unit)
        {
            if (((AsianColony)colony).eastIndiamen)
            {
                unit = unit.DeepCopy();
                unit.woodcost -= 20;
            }
            return base.MakeUnit(unit);
        }
    }
}
