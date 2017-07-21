using System;

namespace BuildOrders
{
    [Serializable]
    public class JapaneseTownCenter : TownCenter
    {
        public JapaneseTownCenter() { }

        public override void SetInitialAllowedTechs()
        {
            //No techs here
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Villager);
        }
    }
}
