using System;

namespace BuildOrders
{
    [Serializable]
    public abstract class Market : Building
    {
        public Market()
        {
            commonName = "Market";
        }
    }
}
