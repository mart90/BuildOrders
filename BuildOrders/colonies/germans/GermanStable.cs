using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class GermanStable : Stable
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.WarWagon,
                cUnit.Uhlan,
            });
        }
    }
}
