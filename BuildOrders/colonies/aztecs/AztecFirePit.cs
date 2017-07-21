using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class AztecFirePit : FirePit
    {
        public override void SetAllowedDances()
        {
            allowedDances.AddRange(new List<Dance>
            {
                Dance.Fertility,
                Dance.Gift,
                Dance.Holy,
            });
        }
    }
}
