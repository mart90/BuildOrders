using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class SiouxWarHut : WarHut
    {
        public override void SetInitialAllowedTechs() { }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.CetanBow,
                cUnit.WarClub,
                cUnit.WakinaRifle,
            });
        }
    }
}
