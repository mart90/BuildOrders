﻿using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class FrenchStable : Stable
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Hussar,
                cUnit.Dragoon,
                cUnit.Cuirassier,
            });
        }
    }
}
