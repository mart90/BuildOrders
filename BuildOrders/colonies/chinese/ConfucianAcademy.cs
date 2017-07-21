using System;

namespace BuildOrders
{
    [Serializable]
    public class ConfucianAcademy : UnitBuilding
    {
        public ConfucianAcademy()
        {
            commonName = "ConfucianAcademy";
            maxUnitsQueued = 1;
        }

        public override void SetInitialAllowedTechs() { }

        public override void SetInitialAllowedUnits() { }

        public void MakeFlyingCrow()
        {
            MakeUnit(cUnit.FlyingCrow);
            timer = 240;
        }
    }
}
