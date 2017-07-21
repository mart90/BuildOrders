using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class RussianTownCenter : TownCenter
    {
        public override void SetInitialAllowedTechs()
        {
            allowedTechs.AddRange(new List<ConstTech>
            {
                cTech.Bishop,
                cTech.PhilosophersPrince,
                cTech.Quartermaster,

                cTech.ExilePrince,
                cTech.Marksman,
                cTech.Scout,

                cTech.KingsMusketeer,
                cTech.Engineer,
                cTech.CavalryMarshal,
                cTech.WarMinister,
            });
        }

        public override void SetInitialAllowedUnits()
        {
            allowedUnits.Add(cUnit.VillagerBatch);
        }
    }
}
