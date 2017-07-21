using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class NoblesHut : UnitBuilding
    {
        public NoblesHut()
        {
            commonName = "NoblesHut";
        }

        public override void SetInitialAllowedTechs() { }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.ArrowKnight,
                cUnit.JaguarProwlKnight,
                cUnit.EagleRunnerKnight,
            });
        }
    }
}
