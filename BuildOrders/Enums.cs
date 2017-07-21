using System;

namespace BuildOrders
{
    [Serializable]
    public enum Resource
    {
        Default,

        Food,
        Wood,
        Coin,
    }

    [Serializable]
    public enum Alliance
    {
        Default,

        British,
        Portuguese,
        Dutch,
        Ottomans,
        French,
        Germans,
        Japanese,
        Russians,
        Spanish,
    }

    [Serializable]
    public enum Dance
    {
        Default,
        
        Fertility,
        Gift,
        Holy,
    }
}