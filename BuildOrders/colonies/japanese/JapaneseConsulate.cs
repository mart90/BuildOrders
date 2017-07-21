using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class JapaneseConsulate : Consulate
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.AllyPortuguese,
                cTech.AllyJapanese,
                cTech.AllyDutch,
                cTech.AllySpanish,
            });
        }

        public override void SetInitialAllowedUnits() { }

        public override void SetNoAlliance()
        {
            ClearAllowed();
            alliance = Alliance.Default;

            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.AllyPortuguese,
                cTech.AllyJapanese,
                cTech.AllyDutch,
                cTech.AllySpanish,
            });
        }

        public void SetAllyPortuguese()
        {
            ClearAllowed();
            alliance = Alliance.Portuguese;

            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.CancelAlliance,
                cTech.FishingFleet,
                cTech.PortugueseExpeditionaryCompany,
                cTech.PortugueseExpeditionaryForce,
            });
        }

        public void SetAllyJapanese()
        {
            ClearAllowed();
            alliance = Alliance.Japanese;

            allowedUnits.AddRange(new List<ConstUnit>
            {
                cUnit.KonshaYamabushi,
                cUnit.ShinobiNoMono,
            });

            allowedTechs.Add(cTech.CancelAlliance);
        }

        public void SetAllyDutch()
        {
            ClearAllowed();
            alliance = Alliance.Dutch;

            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.CancelAlliance,
                cTech.DutchExpeditionaryCompany,
                cTech.DutchExpeditionaryForce,
                cTech.BankWagon,
            });
        }

        public void SetAllySpanish()
        {
            ClearAllowed();
            alliance = Alliance.Spanish;

            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.CancelAlliance,
                cTech.SpanishExpeditionaryCompany,
                cTech.SpanishExpeditionaryForce,
            });
        }
    }
}
