using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    class AsianDock : Dock
    {
        public override void SetInitialAllowedTechs() { }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.FishingBoat
            });
        }
    }
}
