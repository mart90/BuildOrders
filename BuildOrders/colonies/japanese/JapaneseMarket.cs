using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class JapaneseMarket : AsianMarket
    {
        public override void SetInitialAllowedTechs()
        {
			allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.HanamiParties,
                cTech.WaterWheel,
                cTech.BlanketFilters,
                cTech.CivilServants,
			});
        }
    }
}
