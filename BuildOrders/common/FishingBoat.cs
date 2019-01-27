using System;

namespace BuildOrders
{
    [Serializable]
    public class FishingBoat : IGatherer
    {
        public Resource resourceGathering { get; set; } = Resource.Default;
        public bool idle { get; set; } = true;

        public void StopGathering()
        {
            resourceGathering = Resource.Default;
            idle = true;
        }

        public void GatherResource(Resource resource)
        {
            if (resource != Resource.Wood)
            {
                resourceGathering = resource;
                idle = false;
            }
        }
    }
}
