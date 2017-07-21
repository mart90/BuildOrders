using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class NativeMarket : Market
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.HuntingDogs,
                cTech.PlacerMines,
                cTech.LumberCeremony,
            });
        }
    }
}
