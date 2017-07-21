using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class SpanishBarracks : Barracks
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Rodelero,
                cUnit.Skirmisher,
                cUnit.Pikeman,
                cUnit.Crossbowman,
            });
        }
    }
}
