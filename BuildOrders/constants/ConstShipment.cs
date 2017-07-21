using System;

namespace BuildOrders
{
    [Serializable]
    public class ConstShipment
    {
        public ConstShipment(string name, int ageavailable, int populationcost = 0, bool infinite = false,
            int foodcost = 0, int woodcost = 0, int coincost = 0, bool resendable = false)
        {
            this.name = name;
            this.ageavailable = ageavailable;
            this.infinite = infinite;
            this.foodcost = foodcost;
            this.woodcost = woodcost;
            this.coincost = coincost;
            this.populationcost = populationcost;
            this.resendable = resendable;
        }
        public ConstShipment() { }

        public string name;
        public int ageavailable;
        public bool infinite;
        public int foodcost, woodcost, coincost;
        public int populationcost;
        public bool resendable;

        public ConstShipment DeepCopy()
        {
            return new ConstShipment(name, ageavailable, populationcost, infinite, foodcost, woodcost, coincost, resendable);
        }
    }
}
