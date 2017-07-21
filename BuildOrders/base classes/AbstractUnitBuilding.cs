using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public abstract class UnitBuilding : Building
    {
        public UnitBuilding()
        {
            maxUnitsQueued = 5;
            SetInitialAllowedUnits();
        }

        public List<ConstUnit> allowedUnits = new List<ConstUnit>();
        public ConstUnit unitQueued = null;
        public int unitsQueued = 0;
        public int maxUnitsQueued = 0;

        public abstract void SetInitialAllowedUnits();

        public void MakeUnit(ConstUnit unit)
        {
            busy = true;
            unitQueued = unit;
            unitsQueued = 1;
            timer = unit.traintime;
        }

        public override void ClearQueue()
        {
            base.ClearQueue();
            unitQueued = null;
            unitsQueued = 0;
        }
    }
}
