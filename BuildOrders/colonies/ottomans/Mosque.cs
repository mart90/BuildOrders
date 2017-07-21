using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Mosque : Building
    {
        public Mosque()
        {
            commonName = "Mosque";
        }

        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.MilletSystem,
                cTech.GalataTowerDistrict,
            });
        }
    }
}
