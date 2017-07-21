using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class EuropeanMarket : Market
    {
        public override void SetInitialAllowedTechs()
        {
			allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.HuntingDogs,
                cTech.GangSaw,
                cTech.PlacerMines,
			});
        }
    }
}
