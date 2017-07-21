using System;

namespace BuildOrders
{
    [Serializable]
    public abstract class Consulate : UnitBuilding
    {
        public Consulate()
        {
            commonName = "Consulate";
        }

        public Alliance alliance = Alliance.Default;

        public abstract void SetNoAlliance();

        public void ClearAllowed()
        {
            allowedUnits.Clear();
            allowedTechs.Clear();
        }
    }
}
