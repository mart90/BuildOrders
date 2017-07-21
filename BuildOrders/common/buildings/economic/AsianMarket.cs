using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class AsianMarket : Market
    {
        public override void SetInitialAllowedTechs()
        {
			allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.HuntingEagles,
                cTech.WaterWheel,
                cTech.BlanketFilters,
                cTech.CivilServants,
			});
        }
    }
}
