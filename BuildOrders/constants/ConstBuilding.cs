using System;

namespace BuildOrders
{
    [Serializable]
    public class ConstBuilding
    {
        public ConstBuilding(string name, int foodcost, int woodcost, int coincost, int buildtime, int ageavailable, int buildxp)
        {
            this.name = name;
            this.foodcost = foodcost;
            this.woodcost = woodcost;
            this.coincost = coincost;
            this.buildtime = buildtime;
            this.ageavailable = ageavailable;
            this.buildxp = buildxp;
        }
        public ConstBuilding() { }

        public string name;
        public int foodcost, woodcost, coincost;
        public int buildtime;
        public int ageavailable;
        public int buildxp;

        public ConstBuilding DeepCopy()
        {
            return new ConstBuilding(name, foodcost, woodcost, coincost, buildtime, ageavailable, buildxp);
        }
    }
}