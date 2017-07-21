using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class OttomanBarracks : Barracks
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Janissary,
            });
        }
    }
}
