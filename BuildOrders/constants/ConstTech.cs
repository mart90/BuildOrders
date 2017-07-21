using System;

namespace BuildOrders
{
    [Serializable]
    public class ConstTech
    {
        public ConstTech(string name, int foodcost, int woodcost, int coincost, int traintime, int ageavailable, int exportcost = 0)
        {
            this.name = name;
            this.foodcost = foodcost;
            this.woodcost = woodcost;
            this.coincost = coincost;
            this.traintime = traintime;
            this.ageavailable = ageavailable;
            this.exportcost = exportcost;
        }
        public ConstTech() { }

        public string name;
        public int foodcost, woodcost, coincost, exportcost;
        public int traintime;
        public int ageavailable;

        public ConstTech DeepCopy()
        {
            return new ConstTech(name, foodcost, woodcost, coincost, traintime, ageavailable, exportcost);
        }
    }
}
