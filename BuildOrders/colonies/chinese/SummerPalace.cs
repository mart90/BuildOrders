using System;

namespace BuildOrders
{
    [Serializable]
    public class SummerPalace : UnitBuilding
    {
        public SummerPalace()
        {
            commonName = "SummerPalace";
            maxUnitsQueued = 1;
        }

        public override void SetInitialAllowedTechs() { }

        public override void SetInitialAllowedUnits() { }

        public void MakeOldHanArmy()
        {
            MakeUnit(cUnit.OldHanArmy);
            timer = 153;
        }

        public void MakeForbiddenArmy()
        {
            MakeUnit(cUnit.OldHanArmy);
            timer = 294;
        }
    }
}
