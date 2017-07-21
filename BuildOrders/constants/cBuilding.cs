using System;
using System.Reflection;

namespace BuildOrders
{
    [Serializable]
    public static class cBuilding
    {
        public static ConstBuilding GetFieldByName(string name)
        {
            try
            {
                return (ConstBuilding)typeof(cBuilding).GetField(name, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public).GetValue(null);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        //Economic
        public static ConstBuilding TownCenter          = new ConstBuilding("TownCenter", 0, 600, 0, 60, 1, 0);
        public static ConstBuilding House               = new ConstBuilding("House", 0, 100, 0, 10, 1, 20);
        public static ConstBuilding Market              = new ConstBuilding("Market", 0, 100, 0, 15, 1, 20);
        public static ConstBuilding TradingPost         = new ConstBuilding("TradingPost", 0, 200, 0, 30, 1, 40);
        public static ConstBuilding Consulate           = new ConstBuilding("Consulate", 0, 200, 0, 50, 1, 50);
        public static ConstBuilding FirePit             = new ConstBuilding("FirePit", 0, 100, 0, 20, 1, 10);

        //EU military
        public static ConstBuilding Barracks            = new ConstBuilding("Barracks", 0, 200, 0, 30, 2, 20);
        public static ConstBuilding Stable              = new ConstBuilding("Stable", 0, 200, 0, 30, 2, 20);
        public static ConstBuilding ArtilleryFoundry    = new ConstBuilding("ArtilleryFoundry", 0, 300, 0, 30, 3, 30);

        //Asian military
        public static ConstBuilding Caravanserai        = new ConstBuilding("Caravanserai", 0, 200, 0, 30, 2, 20);
        public static ConstBuilding Castle              = new ConstBuilding("Castle", 0, 250, 100, 60, 1, 70);

        //Native military
        public static ConstBuilding WarHut              = new ConstBuilding("WarHut", 0, 250, 0, 50, 1, 25);
        public static ConstBuilding Corral              = new ConstBuilding("Corral", 0, 200, 0, 30, 2, 20);
        public static ConstBuilding NoblesHut           = new ConstBuilding("NoblesHut", 0, 200, 100, 40, 3, 30);

        //Unique economic
        public static ConstBuilding Manor               = new ConstBuilding("Manor", 0, 135, 0, 20, 1, 27);
        public static ConstBuilding ManorWithVC         = new ConstBuilding("Manor", 0, 88, 0, 20, 1, 27);
        public static ConstBuilding IndianHouse         = new ConstBuilding("House", 0, 80, 0, 10, 1, 15);
        public static ConstBuilding Shrine              = new ConstBuilding("Shrine", 0, 125, 0, 15, 1, 25);
        public static ConstBuilding Village             = new ConstBuilding("Village", 0, 200, 0, 20, 1, 20);
        public static ConstBuilding Longhouse           = new ConstBuilding("Longhouse", 0, 125, 0, 10, 1, 25);
        public static ConstBuilding Mosque              = new ConstBuilding("Mosque", 0, 150, 0, 20, 1, 15);
        public static ConstBuilding Bank                = new ConstBuilding("Bank", 300, 350, 0, 30, 1, 130);

        //Unique military
        public static ConstBuilding WarAcademy          = new ConstBuilding("WarAcademy", 0, 200, 0, 30, 2, 20);
        public static ConstBuilding Blockhouse          = new ConstBuilding("Blockhouse", 0, 250, 0, 50, 1, 35);

        //Indian wonders
        public static ConstBuilding AgraFort            = new ConstBuilding("AgraFort", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding KarniMata           = new ConstBuilding("KarniMata", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding TowerOfVictory      = new ConstBuilding("TowerOfVictory", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding CharminarGate       = new ConstBuilding("CharminarGate", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding TajMahal            = new ConstBuilding("TajMahal", 0, 0, 0, 0, 0, 0);

        //Japanese wonders
        public static ConstBuilding ToshoguShrine       = new ConstBuilding("ToshoguShrine", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding GoldenPavilion      = new ConstBuilding("GoldenPavilion", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding Shogunate           = new ConstBuilding("Shogunate", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding ToriiGates          = new ConstBuilding("ToriiGates", 0, 0, 0, 0, 0, 0);

        //Chinese wonders
        public static ConstBuilding PorcelainTower      = new ConstBuilding("PorcelainTower", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding WhitePagoda         = new ConstBuilding("WhitePagoda", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding SummerPalace        = new ConstBuilding("SummerPalace", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding ConfucianAcademy    = new ConstBuilding("ConfucianAcademy", 0, 0, 0, 0, 0, 0);
        public static ConstBuilding TempleOfHeaven      = new ConstBuilding("TempleOfHeaven", 0, 0, 0, 0, 0, 0);
    }
}
