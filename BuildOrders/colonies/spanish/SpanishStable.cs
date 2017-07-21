using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class SpanishStable : Stable
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Lancer,
                cUnit.Hussar,
                cUnit.Dragoon,
            });
        }
    }
}
