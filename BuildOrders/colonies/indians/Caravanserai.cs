using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Caravanserai : UnitBuilding
    {
        public Caravanserai()
        {
            commonName = "Caravanserai";
        }

        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
			allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.Sowar,
                cUnit.Zamburak,
                cUnit.Mahout,
                cUnit.Howdah,
			});
        }
    }
}
