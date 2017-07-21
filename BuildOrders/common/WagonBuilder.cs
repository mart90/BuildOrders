using System;

namespace BuildOrders
{
    [Serializable]
    public class WagonBuilder : IBuilder
    {
        public WagonBuilder(ConstBuilding building, int timer)
        {
            buildingQueued = building;
            this.timer = timer;
        }

        public WagonBuilder() { }

        public ConstBuilding buildingQueued { get; set; }
        public int timer { get; set; }

        public void MakeBuilding(ConstBuilding building)
        {
            buildingQueued = building;
            timer = building.buildtime;
        }

        public void MakeBuilding(ConstBuilding building, int timer)
        {
            buildingQueued = building;
            this.timer = timer;
        }

        public bool ConstructionFinished()
        {
            return timer <= 0;
        }

        public void ClearQueue() { }
    }
}
