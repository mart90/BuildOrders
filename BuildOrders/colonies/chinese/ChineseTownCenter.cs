using System;

namespace BuildOrders
{
    [Serializable]
    public class ChineseTownCenter : TownCenter
    {
        public ChineseTownCenter() { }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Villager);
        }

        public override void SetInitialAllowedTechs()
        {
        }
    }
}
