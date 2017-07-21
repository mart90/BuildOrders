using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Explorer : IBuilder
    {
        public Explorer()
        {
            SetAllowedBuildings();
        }

        public List<ConstBuilding> allowedBuildings = new List<ConstBuilding>();

        public bool constructing = false;
        public ConstBuilding buildingQueued { get; set; }
        public int timer { get; set; }

        public virtual void SetAllowedBuildings()
        {
            allowedBuildings.AddRange(new List<ConstBuilding>
            {
                cBuilding.TownCenter,
                cBuilding.TradingPost,
            });
        }

        public void MakeBuilding(ConstBuilding building)
        {
            constructing = true;
            buildingQueued = building;
            timer = building.buildtime;
        }

        public bool ConstructionFinished()
        {
            return timer <= 0;
        }

        public void ClearQueue()
        {
            constructing = false;
            buildingQueued = null;
            timer = 0;
        }
    }
}

