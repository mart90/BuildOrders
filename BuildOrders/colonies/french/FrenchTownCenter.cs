using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class FrenchTownCenter : TownCenter
    {
        public FrenchTownCenter() { }

        public override void SetInitialAllowedTechs()
        {
			allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.Governor,
                cTech.PhilosophersPrince,
                cTech.Quartermaster,
                
                cTech.Marksman,
                cTech.ExilePrince,
                cTech.Scout,

                cTech.Tycoon,
                cTech.KingsMusketeer,
                cTech.Engineer,
                cTech.CavalryMarshal,
			});
        }
		
        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.Coureur);
        }
    }
}
