using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class OttomanArtilleryFoundry : ArtilleryFoundry
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.AbusGun,
                cUnit.Culverin,
                cUnit.Falconet,
            });
        }
    }
}
