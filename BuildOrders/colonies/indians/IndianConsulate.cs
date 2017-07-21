using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class IndianConsulate : Consulate
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.AllyBritish,
                cTech.AllyFrench,
                cTech.AllyOttomans,
            });
        }

        public override void SetInitialAllowedUnits() { }

        public override void SetNoAlliance()
        {
            ClearAllowed();
            alliance = Alliance.Default;

            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.AllyBritish,
                cTech.AllyFrench,
                cTech.AllyOttomans,
            });
        }

        public void SetAllyFrench()
        {
            ClearAllowed();
            alliance = Alliance.French;

            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.CancelAlliance,
                cTech.Crates500f,
                cTech.Crates500w,
                cTech.Crates500c,
            });
        }

        public void SetAllyOttomans()
        {
            ClearAllowed();
            alliance = Alliance.Ottomans;

            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.CancelAlliance,
                cTech.Vills4,
                cTech.OttomanExpeditionaryCompany,
                cTech.OttomanExpeditionaryForce,
            });
        }

        public void SetAllyBritish()
        {
            ClearAllowed();
            alliance = Alliance.British;

            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.CancelAlliance,
                cTech.BritishExpeditionaryCompany,
                cTech.BritishExpeditionaryForce,
            });
        }
    }
}
