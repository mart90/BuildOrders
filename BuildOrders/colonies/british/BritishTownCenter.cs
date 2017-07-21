using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class BritishTownCenter : TownCenter
    {
        public BritishTownCenter() { }

        public override void SetInitialAllowedTechs()
        {
			allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.PhilosophersPrince,
                cTech.Bishop,
                cTech.Governor,

                cTech.AdmiralOfOcean,
                cTech.Adventurer,

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
