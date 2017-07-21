using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Factory : UnitBuilding
    {
        public Factory()
        {
            commonName = "Factory";
            maxUnitsQueued = 1;
        }

        public bool unitProduction;

        public override void SetInitialAllowedTechs()
        {
			allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.Cannery,
                cTech.SteamPower,
                cTech.WaterPower,
                cTech.MassProduction,
			});
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.HeavyCannon);
        }
    }
}
