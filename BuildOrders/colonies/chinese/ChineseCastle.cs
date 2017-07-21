using System;

namespace BuildOrders
{
    [Serializable]
    public class ChineseCastle : Castle
    {
        public override void SetInitialAllowedTechs() { }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.HandMortar);
        }
    }
}
