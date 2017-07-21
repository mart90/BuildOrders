using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class IroquoisTownCenter : TownCenter
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.WiseWoman,
                cTech.Chief,
                cTech.Messenger,
                cTech.Warrior,
                cTech.Shaman,
            });
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Villager);
        }
    }
}
