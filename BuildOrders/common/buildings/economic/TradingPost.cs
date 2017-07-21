using System;

namespace BuildOrders
{
    [Serializable]
    public class TradingPost : Building
    {
        public TradingPost()
        {
            commonName = "TradingPost";
        }

        public override void SetInitialAllowedTechs()
        {
            allowedTechs.Add(cTech.StageCoach);
        }
    }
}
