using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class OttomanTownCenter : TownCenter
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.Governor,
                cTech.PhilosophersPrince,
                cTech.Quartermaster,

                cTech.ExilePrince,
                cTech.AdmiralOfOcean,
                cTech.Marksman,
                cTech.Scout,

                cTech.Tycoon,
                cTech.Engineer,
                cTech.CavalryMarshal,
                cTech.GrandVizier,
            });
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Villager);
        }
    }
}
