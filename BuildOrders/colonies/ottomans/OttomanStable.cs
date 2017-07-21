using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class OttomanStable : Stable
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Hussar,
                cUnit.CavalryArcher,
            });
        }
    }
}
