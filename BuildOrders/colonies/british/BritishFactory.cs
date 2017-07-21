using System;

namespace BuildOrders
{
	[Serializable]
    public class BritishFactory : Factory
    {
        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Rocket);
        }
    }
}
