using System;

namespace BuildOrders
{
    [Serializable]
    public class JapaneseCastle : Castle
    {
        public override void SetInitialAllowedTechs()
        {

        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.FlamingArrow);
        }
    }
}
