using System;

namespace BuildOrders
{
    [Serializable]
    public class ConstUnit
    {
        public ConstUnit(string name, int foodcost, int woodcost, int coincost, int populationcost, int traintime, int ageavailable, int buildxp, int exportcost = 0)
        {
            this.name = name;
            this.foodcost = foodcost;
            this.woodcost = woodcost;
            this.coincost = coincost;
            this.populationcost = populationcost;
            this.traintime = traintime;
            this.ageavailable = ageavailable;
            this.buildxp = buildxp;
            this.exportcost = exportcost;
        }
        public ConstUnit() { }

        public string name;
        public int foodcost, woodcost, coincost, exportcost;
        public int populationcost;
        public int traintime;
        public int ageavailable;
        public int buildxp;

        public ConstUnit DeepCopy()
        {
            return new ConstUnit(name, foodcost, woodcost, coincost, populationcost, traintime, ageavailable, buildxp, exportcost);
        }

    }
}
