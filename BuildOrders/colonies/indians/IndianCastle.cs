using System;

namespace BuildOrders
{
    [Serializable]
    public class IndianCastle : Castle
    {
        public override void SetInitialAllowedTechs()
        {
            
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.SiegeElephant);
        }
    }
}
