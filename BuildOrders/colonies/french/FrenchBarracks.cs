using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class FrenchBarracks : Barracks
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Crossbowman,
                cUnit.Musketeer,
                cUnit.Pikeman,
                cUnit.Skirmisher,
            });
        }
    }
}
