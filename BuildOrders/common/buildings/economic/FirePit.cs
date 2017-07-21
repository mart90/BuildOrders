using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public abstract class FirePit
    {
        public FirePit()
        {
            SetAllowedDances();
        }

        public Dance dance = Dance.Gift;
        public double danceTimer;
        public List<Villager> dancingVillagers = new List<Villager>();
        public List<Dance> allowedDances = new List<Dance>();

        public abstract void SetAllowedDances();
    }
}
