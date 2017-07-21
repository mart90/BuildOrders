using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class PortugueseTownCenter : TownCenter
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.PhilosophersPrince,
                cTech.Bishop,
                cTech.Quartermaster,

                cTech.AdmiralOfOcean,
                cTech.Marksman,
                cTech.ExilePrince,

                cTech.Tycoon,
                cTech.KingsMusketeer,
                cTech.Engineer,
                cTech.Viceroy,
            });
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Villager);
        }
    }
}
