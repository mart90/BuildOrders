using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class SpanishTownCenter : TownCenter
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.Bishop,
                cTech.Governor,
                cTech.PhilosophersPrince,

                cTech.AdmiralOfOcean,
                cTech.Adventurer,
                cTech.SergeantAtArms,
                cTech.Scout,

                cTech.KingsMusketeer,
                cTech.Engineer,
                cTech.CavalryMarshal,
                cTech.WarMinister,
            });
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Villager);
        }
    }
}
