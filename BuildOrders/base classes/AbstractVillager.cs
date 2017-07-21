using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public abstract class Villager : IBuilder
    {
        public Villager()
        {
            SetAllowedBuildings();
            allowedBuildings.Add(new ConstBuilding("Dummy", 0, 0, 0, 0, 1, 0));
        }

        public List<ConstBuilding> allowedBuildings = new List<ConstBuilding>();

        public Resource resourceGathering = Resource.Default;
        public bool idle = true;
        public bool constructing;
        public ConstBuilding buildingQueued { get; set; }
        public int timer { get; set; }

        public abstract void SetAllowedBuildings();

        public void MakeBuilding(ConstBuilding building)
        {
            resourceGathering = Resource.Default;
            idle = false;
            constructing = true;
            buildingQueued = building;
            timer = building.buildtime;
        }

        public void StopGathering()
        {
            resourceGathering = Resource.Default;
            idle = true;
        }

        public void GatherResource(Resource resource)
        {
            resourceGathering = resource;
            idle = false;
        }

        public bool ConstructionFinished()
        {
            return timer <= 0;
        }

        public void ClearQueue()
        {
            idle = true;
            constructing = false;
            buildingQueued = null;
            timer = 0;
        }
    }
}
