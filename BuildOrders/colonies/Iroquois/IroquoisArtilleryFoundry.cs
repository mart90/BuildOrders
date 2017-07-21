using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class IroquoisArtilleryFoundry : ArtilleryFoundry
    {
        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Mantlet,
                cUnit.LightCannon,
            });
        }
    }
}
