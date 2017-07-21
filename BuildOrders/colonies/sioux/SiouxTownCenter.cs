using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class SiouxTownCenter : TownCenter
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.WiseWoman,
                cTech.Warrior,
                cTech.Messenger,
                cTech.Shaman,
                cTech.Chief,
            });
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Villager);
        }
    }
}
