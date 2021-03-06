﻿using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class BritishBarracks : Barracks
    {
        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
			allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Longbowman,
                cUnit.Pikeman,
                cUnit.Musketeer,
			});
        }
    }
}
