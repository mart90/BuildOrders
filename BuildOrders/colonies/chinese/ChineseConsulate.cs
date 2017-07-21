using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class ChineseConsulate : Consulate
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.AllyBritish,
                cTech.AllyFrench,
                cTech.AllyGermans,
                cTech.AllyRussians,
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
                cTech.AllyGermans,
                cTech.AllyRussians,
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

        public void SetAllyGermans()
        {
            ClearAllowed();
            alliance = Alliance.Germans;

            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.CancelAlliance,
                cTech.GermanExpeditionaryCompany,
                cTech.GermanExpeditionaryForce,
            });
        }

        public void SetAllyRussians()
        {
            ClearAllowed();
            alliance = Alliance.Russians;

            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.CancelAlliance,
                cTech.RussianExpeditionaryCompany,
                cTech.RussianExpeditionaryForce,
            });
        }
    }
}
