using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class PortugueseBarracks : Barracks
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Musketeer,
                cUnit.Crossbowman,
                cUnit.Pikeman,
                cUnit.Cassadore,
            });
        }
    }
}
