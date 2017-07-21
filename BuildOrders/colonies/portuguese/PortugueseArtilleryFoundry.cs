using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class PortugueseArtilleryFoundry : ArtilleryFoundry
    {
        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.OrganGun,
                cUnit.Culverin,
            });
        }
    }
}
