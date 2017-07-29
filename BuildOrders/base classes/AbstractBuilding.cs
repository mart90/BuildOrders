using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public abstract class Building
    {
        public Building()
        {
            SetInitialAllowedTechs();
        }

        public string commonName = "";
        public List<ConstTech> allowedTechs = new List<ConstTech>();

        public bool busy;
        public ConstTech techQueued;
        public double timer;

        public abstract void SetInitialAllowedTechs();

        public void MakeTech(ConstTech tech, int overridetp = 0)
        {
            busy = true;
            techQueued = tech;
            timer = overridetp != 0 ? overridetp : tech.traintime;
        }

        public bool QueueFinished()
        {
            return timer <= 0;
        }

        public virtual void ClearQueue()
        {
            busy = false;
            techQueued = null;
            timer = 0;
        }
    }
}
