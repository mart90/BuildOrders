using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class PortugueseStable : Stable
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Dragoon,
                cUnit.Hussar,
            });
        }
    }
}
