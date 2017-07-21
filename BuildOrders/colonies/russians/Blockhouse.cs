using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Blockhouse : UnitBuilding
    {
        public Blockhouse()
        {
            commonName = "Blockhouse";
        }

        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.StreletBatch,
                cUnit.MusketeerBatch,
                cUnit.Halberdier,
            });
        }
    }
}
