using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class IroquoisWarHut : WarHut
    {
        public override void SetInitialAllowedTechs() { }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Aenna,
                cUnit.Tomahawk,
                cUnit.ForestProwler,
            });
        }
    }
}
