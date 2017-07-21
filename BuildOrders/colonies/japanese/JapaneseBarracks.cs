﻿using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class JapaneseBarracks : Barracks
    {
        public override void SetInitialAllowedTechs()
        {

        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Yumi,
                cUnit.Ashigaru,
            });
        }
    }
}
