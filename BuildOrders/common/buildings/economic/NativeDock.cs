using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class NativeDock : Dock
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.GillNets,
                cTech.LongLines
            });
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.FishingBoat
            });
        }
    }
}
