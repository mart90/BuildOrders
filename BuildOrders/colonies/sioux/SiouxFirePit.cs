using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class SiouxFirePit : FirePit
    {
        public override void SetAllowedDances()
        {
            allowedDances.AddRange(new List<Dance>
            {
                Dance.Fertility,
                Dance.Gift,
            });
        }
    }
}
