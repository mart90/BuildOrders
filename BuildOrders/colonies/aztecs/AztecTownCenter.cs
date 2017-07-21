using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class AztecTownCenter : TownCenter
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.Warrior,
                cTech.Messenger,
                cTech.Chief,
                cTech.Shaman,
            });
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Villager);
        }
    }
}
