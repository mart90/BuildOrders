using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class WarAcademy : UnitBuilding
    {
        public WarAcademy()
        {
            commonName = "WarAcademy";
            maxUnitsQueued = 1;
        }

        public override void SetInitialAllowedTechs()
        {
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.OldHanArmy,
                cUnit.StandardArmy,
                cUnit.MingArmy,
                cUnit.TerritorialArmy,
                cUnit.ForbiddenArmy,
                cUnit.ImperialArmy,
            });
        }
    }
}
