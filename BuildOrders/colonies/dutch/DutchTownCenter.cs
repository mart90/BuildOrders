using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class DutchTownCenter : TownCenter
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
                cTech.SergeantAtArms,
                
                cTech.Tycoon,
                cTech.KingsMusketeer,
                cTech.Viceroy,
                cTech.CavalryMarshal,
            });
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.DutchVillager);
        }
    }
}
