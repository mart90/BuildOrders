using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class GermanTownCenter : TownCenter
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.Bishop,
                cTech.PhilosophersPrince,
                cTech.Quartermaster,

                cTech.ExilePrince,
                cTech.SergeantAtArms,
                cTech.Marksman,

                cTech.Tycoon,
                cTech.Engineer,
                cTech.Viceroy,
                cTech.CavalryMarshal,
            });
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Villager);
        }
    }
}
