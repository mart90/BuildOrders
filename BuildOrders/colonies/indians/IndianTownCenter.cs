using System;

namespace BuildOrders
{
    [Serializable]
    public class IndianTownCenter : TownCenter
    {
        public IndianTownCenter() { }

        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Villager);
        }
    }
}
