using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class DutchStable : Stable
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Hussar,
                cUnit.Ruyter,
            });
        }
    }
}
