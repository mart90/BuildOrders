using System;
using System.Reflection;

namespace BuildOrders
{
    [Serializable]
    public static class cShipment
    {
        public static ConstShipment GetFieldByName(string name)
        {
            try
            {
                return (ConstShipment)typeof(cShipment).GetField(name, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public).GetValue(null);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        //DISCOVERY
        //EU
        public static ConstShipment Crates300w          = new ConstShipment("Crates300w", 1, 0, true);
        public static ConstShipment Vills3              = new ConstShipment("Vills3", 1, 3);
        public static ConstShipment SettlerWagon2       = new ConstShipment("SettlerWagon2", 1, 4);
        public static ConstShipment VirginiaCompany     = new ConstShipment("VirginiaCompany", 1);
        public static ConstShipment EconomicTheory      = new ConstShipment("EconomicTheory", 1);
        public static ConstShipment AdvancedTradingPost = new ConstShipment("AdvancedTradingPost", 1);
        public static ConstShipment SilkRoad            = new ConstShipment("SilkRoad", 1);
        public static ConstShipment Distributivism      = new ConstShipment("Distributivism", 1);
        public static ConstShipment BankOfAmsterdam     = new ConstShipment("BankOfAmsterdam", 1);
        public static ConstShipment BankOfRotterdam     = new ConstShipment("BankOfRotterdam", 1);

        //Asian
        public static ConstShipment Vills2              = new ConstShipment("Vills2", 1, 2, false, 0, 0, 0, true);
        public static ConstShipment GoodFaithAgreements = new ConstShipment("GoodFaithAgreements", 1);
        public static ConstShipment HeavenlyKami        = new ConstShipment("HeavenlyKami", 1);
        public static ConstShipment NorthernRefugees    = new ConstShipment("NorthernRefugees", 1);

        //COLONIAL
        //EU
        public static ConstShipment Vills4              = new ConstShipment("Vills4", 2, 4, false, 0, 0, 0, true);
        public static ConstShipment Vills5              = new ConstShipment("Vills5", 2, 5);
        public static ConstShipment ColoSettlerWagon2   = new ConstShipment("ColoSettlerWagon2", 2, 4);
        public static ConstShipment SettlerWagon3       = new ConstShipment("SettlerWagon3", 2, 6);
        public static ConstShipment SpiceTrade          = new ConstShipment("SpiceTrade", 2);
        public static ConstShipment Crates600w          = new ConstShipment("Crates600w", 2, 0, false, 0, 0, 0, true);
        public static ConstShipment Crates600c          = new ConstShipment("Crates600c", 2, 0, true, 0, 0, 0, true);
        public static ConstShipment Crates700w          = new ConstShipment("Crates700w", 2);
        public static ConstShipment Crates700c          = new ConstShipment("Crates700c", 2);
        public static ConstShipment Crates700f          = new ConstShipment("Crates700f", 2);
        public static ConstShipment Crates600f          = new ConstShipment("Crates600f", 2, 0, false, 0, 0, 0, true);
        public static ConstShipment BankWagon           = new ConstShipment("BankWagon", 2);
        public static ConstShipment Boyars              = new ConstShipment("Boyars", 2);

        public static ConstShipment Crossbowman8        = new ConstShipment("Crossbowman8", 2, 8);
        public static ConstShipment Pikeman8            = new ConstShipment("Pikeman8", 2, 8);
        public static ConstShipment Hussar3             = new ConstShipment("Hussar3", 2, 6);
        public static ConstShipment Longbowman6         = new ConstShipment("Longbowman6", 2, 6);
        public static ConstShipment Musketeer6          = new ConstShipment("Musketeer6", 2, 6);
        public static ConstShipment Doppelsoldner3      = new ConstShipment("Doppelsoldner3", 2, 6);
        public static ConstShipment Uhlan3              = new ConstShipment("Uhlan3", 2, 6);
        public static ConstShipment Janissary5          = new ConstShipment("Janissary5", 2, 5);
        public static ConstShipment Rodelero7           = new ConstShipment("Rodelero7", 2, 7);
        public static ConstShipment Rodelero6           = new ConstShipment("Rodelero6", 2, 6);
        public static ConstShipment Strelet13           = new ConstShipment("Strelet13", 2, 13);
        public static ConstShipment Cossack4            = new ConstShipment("Cossack4", 2, 4);
        public static ConstShipment Cossack5            = new ConstShipment("Cossack5", 2, 5);

        //Asian
        public static ConstShipment Export300           = new ConstShipment("Export300", 2);
        public static ConstShipment ForeignLogging      = new ConstShipment("ForeignLogging", 2);
        public static ConstShipment CherryOrchards      = new ConstShipment("CherryOrchards", 2, 0, false, 0, 0, 0, true);

        public static ConstShipment Sepoy5              = new ConstShipment("Sepoy5", 2, 5);
        public static ConstShipment Sowar4              = new ConstShipment("Sowar4", 2, 8);
        public static ConstShipment Yumi5               = new ConstShipment("Yumi5", 2, 5, false, 0, 0, 0, true);
        public static ConstShipment Ashigaru5           = new ConstShipment("Ashigaru5", 2, 5, false, 0, 0, 0, true);
        public static ConstShipment DaimyoMototada      = new ConstShipment("DaimyoMototada", 2, 4);
        public static ConstShipment ChuKoNu8            = new ConstShipment("ChuKoNu8", 2, 8);
        public static ConstShipment QiangPikeman9       = new ConstShipment("QiangPikeman9", 2, 9);
        public static ConstShipment SteppeRider7        = new ConstShipment("SteppeRider7", 2, 7);

        //Native
        public static ConstShipment NomadicExpansion    = new ConstShipment("NomadicExpansion", 2);

        public static ConstShipment WarriorPriest3      = new ConstShipment("WarriorPriest3", 2, 3);
        public static ConstShipment PumaSpearman6       = new ConstShipment("PumaSpearman6", 2, 6);
        public static ConstShipment CoyoteRunner5       = new ConstShipment("CoyoteRunner5", 2, 5);
        public static ConstShipment Macehualtin10       = new ConstShipment("Macehualtin10", 2, 10);
        public static ConstShipment Macehualtin9        = new ConstShipment("Macehualtin9", 2, 9);
        public static ConstShipment CetanBow6           = new ConstShipment("CetanBow6", 2, 6);
        public static ConstShipment WarClub7            = new ConstShipment("WarClub7", 2, 7);
        public static ConstShipment AxeRider4           = new ConstShipment("AxeRider4", 2, 5);
        public static ConstShipment DogSoldier2         = new ConstShipment("DogSoldier2", 2, 6);
        public static ConstShipment Aenna7              = new ConstShipment("Aenna7", 2, 7);
        public static ConstShipment Aenna6              = new ConstShipment("Aenna6", 2, 6);
        public static ConstShipment Tomahawk6           = new ConstShipment("Tomahawk6", 2, 6);
        public static ConstShipment KanyaHorseman4      = new ConstShipment("KanyaHorseman4", 2, 8);

        //FORTRESS
        //EU
        public static ConstShipment Vills8              = new ConstShipment("Vills8", 3, 8);
        public static ConstShipment Crates1000w         = new ConstShipment("Crates1000w", 3, 0, false, 0, 0, 0, true);
        public static ConstShipment Crates1000c         = new ConstShipment("Crates1000c", 3, 0, false, 0, 0, 0, true);
        public static ConstShipment Crates1000f         = new ConstShipment("Crates1000f", 3);
        public static ConstShipment SuvorovReforms      = new ConstShipment("SuvorovReforms", 3);

        public static ConstShipment Skirmisher8         = new ConstShipment("Skirmisher8", 3, 8);
        public static ConstShipment Skirmisher7         = new ConstShipment("Skirmisher7", 3, 7);
        public static ConstShipment Dragoon5            = new ConstShipment("Dragoon5", 3, 10);
        public static ConstShipment Cuirassier3         = new ConstShipment("Cuirassier3", 3, 9);
        public static ConstShipment Longbowman10        = new ConstShipment("Longbowman10", 3, 10);
        public static ConstShipment Longbowman8         = new ConstShipment("Longbowman8", 3, 8);
        public static ConstShipment Hussar5             = new ConstShipment("Hussar5", 3, 10);
        public static ConstShipment Hussar4             = new ConstShipment("Hussar4", 3, 8);
        public static ConstShipment Pikeman10           = new ConstShipment("Pikeman10", 3, 10);
        public static ConstShipment Musketeer9          = new ConstShipment("Musketeer9", 3, 9);
        public static ConstShipment Falconet2           = new ConstShipment("Falconet2", 3, 8);
        public static ConstShipment Cassador8           = new ConstShipment("Cassador8", 3, 8);
        public static ConstShipment Cassador7           = new ConstShipment("Cassador7", 3, 7);
        public static ConstShipment OrganGun2           = new ConstShipment("OrganGun2", 3, 8);
        public static ConstShipment Doppelsoldner5      = new ConstShipment("Doppelsoldner5", 3, 10);
        public static ConstShipment Uhlan6              = new ConstShipment("Uhlan6", 3, 12);
        public static ConstShipment Uhlan5              = new ConstShipment("Uhlan5", 3, 10);
        public static ConstShipment WarWagon3           = new ConstShipment("WarWagon3", 3, 9);
        public static ConstShipment Ruyter9             = new ConstShipment("Ruyter9", 3, 9);
        public static ConstShipment Ruyter7             = new ConstShipment("Ruyter7", 3, 7);
        public static ConstShipment Janissary8          = new ConstShipment("Janissary8", 3, 8);
        public static ConstShipment AbusGun5            = new ConstShipment("AbusGun5", 3, 10);
        public static ConstShipment CavalryArcher5      = new ConstShipment("CavalryArcher5", 3, 10);
        public static ConstShipment Pikeman12           = new ConstShipment("Pikeman12", 3, 12);
        public static ConstShipment Rodelero8           = new ConstShipment("Rodelero8", 3, 8);
        public static ConstShipment Rodelero9           = new ConstShipment("Rodelero9", 3, 9);
        public static ConstShipment Lancer4             = new ConstShipment("Lancer4", 3, 8);
        public static ConstShipment Lancer5             = new ConstShipment("Lancer5", 3, 10);
        public static ConstShipment Strelet20           = new ConstShipment("Strelet20", 3, 20);
        public static ConstShipment Cossack6            = new ConstShipment("Cossack6", 3, 6);
        public static ConstShipment Oprichnik6          = new ConstShipment("Oprichnik6", 3, 12);

        public static ConstShipment Manchu9             = new ConstShipment("Manchu9", 3, 18, false, 0, 0, 1000);
        public static ConstShipment SwissPikeman12      = new ConstShipment("SwissPikeman12", 3, 24, false, 0, 0, 1000);
        public static ConstShipment Jaeger13            = new ConstShipment("Jaeger13", 3, 26, false, 0, 0, 1000);
        public static ConstShipment Jaeger10            = new ConstShipment("Jaeger10", 3, 20, false, 0, 0, 1000);
        public static ConstShipment Highlander9         = new ConstShipment("Highlander9", 3, 18, false, 0, 0, 1000);
        public static ConstShipment BlackRider9         = new ConstShipment("BlackRider9", 3, 27, false, 0, 0, 1000);
        public static ConstShipment BlackRider7         = new ConstShipment("BlackRider7", 3, 21, false, 0, 0, 1000);
        public static ConstShipment Mameluke4           = new ConstShipment("Mameluke4", 3, 16, false, 0, 0, 1000);
        public static ConstShipment Spahi5              = new ConstShipment("Spahi5", 3, 15, false, 1000, 0, 0);

        //Asian
        public static ConstShipment Vills7              = new ConstShipment("Vills7", 3, 7, false, 0, 0, 0, true);

        public static ConstShipment Urumi7              = new ConstShipment("Urumi7", 3, 14, false, 500);
        public static ConstShipment Sepoy9              = new ConstShipment("Sepoy9", 3, 9);
        public static ConstShipment Gurkha8             = new ConstShipment("Gurkha8", 3, 8);
        public static ConstShipment Gurkha7             = new ConstShipment("Gurkha7", 3, 7);
        public static ConstShipment Mahout2             = new ConstShipment("Mahout2", 3, 14, false, 350);
        public static ConstShipment Mahout3             = new ConstShipment("Mahout3", 3, 21, false, 1000);
        public static ConstShipment Zamburak9           = new ConstShipment("Zamburak9", 3, 9);
        public static ConstShipment Zamburak8           = new ConstShipment("Zamburak8", 3, 8);
        public static ConstShipment Intervention        = new ConstShipment("Intervention", 3);
        public static ConstShipment Howdah2             = new ConstShipment("Howdah2", 3, 12, false, 250);
        public static ConstShipment SiegeElephant2      = new ConstShipment("SiegeElephant2", 3, 14, false, 500);
        public static ConstShipment Yumi9               = new ConstShipment("Yumi9", 3, 9, false, 0, 0, 0, true);
        public static ConstShipment Ashigaru8           = new ConstShipment("Ashigaru8", 3, 8, false, 0, 0, 0, true);
        public static ConstShipment Naginata5           = new ConstShipment("Naginata5", 3, 10, false, 0, 0, 0, true);
        public static ConstShipment FlamingArrow2       = new ConstShipment("FlamingArrow2", 3, 8, false, 0, 0, 0, true);
        public static ConstShipment DaimyoKiyomasa      = new ConstShipment("DaimyoKiyomasa", 3, 4);
        public static ConstShipment ChuKoNu13           = new ConstShipment("ChuKoNu13", 3, 13);
        public static ConstShipment Arquebusier10       = new ConstShipment("Arquebusier10", 3, 10);
        public static ConstShipment ChangdaoSwordsman11 = new ConstShipment("ChangdaoSwordsman11", 11);
        public static ConstShipment MeteorHammer5       = new ConstShipment("MeteorHammer5", 3, 10);
        public static ConstShipment IronFlail4          = new ConstShipment("IronFlail4", 3, 8);
        public static ConstShipment HandMortar7         = new ConstShipment("HandMortar7", 3, 7);

        //Native
        public static ConstShipment Crates800c          = new ConstShipment("Crates800c", 3, 0, true);
        public static ConstShipment Crates1200          = new ConstShipment("Crates1200", 3);

        public static ConstShipment CoyoteRunner10      = new ConstShipment("CoyoteRunner10", 3, 10);
        public static ConstShipment Macehualtin13       = new ConstShipment("Macehualtin13", 3, 13);
        public static ConstShipment EagleRunnerKnight5  = new ConstShipment("EagleRunnerKnight5", 3, 5, true);
        public static ConstShipment EagleRunnerKnight6  = new ConstShipment("EagleRunnerKnight6", 3, 6);
        public static ConstShipment SkullKnight4        = new ConstShipment("SkullKnight4", 3, 8);
        public static ConstShipment JaguarProwlKnight6  = new ConstShipment("JaguarProwlKnight6", 6);
        public static ConstShipment JaguarProwlKnight5  = new ConstShipment("JaguarProwlKnight5", 3, 5, true);
        public static ConstShipment ArrowKnight6        = new ConstShipment("ArrowKnight6", 3, 12);
        public static ConstShipment TempleOfCenteotl    = new ConstShipment("TempleOfCenteotl", 3, 18, false, 0, 0, 1000);
        public static ConstShipment TempleOfTlaloc      = new ConstShipment("TempleOfTlaloc", 3, 8, false, 0, 0, 1000);
        public static ConstShipment WakinaRifle9        = new ConstShipment("WakinaRifle9", 3, 9);
        public static ConstShipment AxeRider5           = new ConstShipment("AxeRider5", 3, 10);
        public static ConstShipment RifleRider4         = new ConstShipment("RifleRider4", 3, 8);
        public static ConstShipment RifleRider5         = new ConstShipment("RifleRider5", 3, 10);
        public static ConstShipment DogSoldier3         = new ConstShipment("DogSoldier3", 3, 9);
        public static ConstShipment SanteeSupport       = new ConstShipment("SanteeSupport", 3, 12, false, 0, 0, 1000);
        public static ConstShipment TwoKettleSupport    = new ConstShipment("TwoKettleSupport", 3, 14, false, 0, 0, 1000);
        public static ConstShipment ForestProwler8      = new ConstShipment("ForestProwler8", 3, 8);
        public static ConstShipment ForestProwler6      = new ConstShipment("ForestProwler6", 3, 6);
        public static ConstShipment Tomahawk9           = new ConstShipment("Tomahawk9", 3, 9);
        public static ConstShipment Tomahawk8           = new ConstShipment("Tomahawk8", 3, 8);
        public static ConstShipment MusketRider5        = new ConstShipment("MusketRider5", 3, 10);
        public static ConstShipment KanyaHorseman6      = new ConstShipment("KanyaHorseman6", 3, 12);
        public static ConstShipment KanyaHorseman5      = new ConstShipment("KanyaHorseman5", 3, 10);
        public static ConstShipment Mantlet5            = new ConstShipment("Mantlet5", 3, 10);
        public static ConstShipment RenegadeFrench      = new ConstShipment("RenegadeFrench", 3, 15, false, 0, 0, 500);

        //INDUSTRIAL
        //EU
        public static ConstShipment Crates1600f         = new ConstShipment("Crates1600f", 4);
        public static ConstShipment Crates1600w         = new ConstShipment("Crates1600w", 4);
        public static ConstShipment Crates1600c         = new ConstShipment("Crates1600c", 4);
        public static ConstShipment Factory             = new ConstShipment("Factory", 4);
        public static ConstShipment RobberBarons        = new ConstShipment("RobberBarons", 4);

        public static ConstShipment Longbowman20        = new ConstShipment("Longbowman20", 4, 20);
        public static ConstShipment Rocket3             = new ConstShipment("Rocket3", 4, 18);
        public static ConstShipment Rocket2             = new ConstShipment("Rocket2", 4, 12, true);
        public static ConstShipment HeavyCannon2        = new ConstShipment("HeavyCannon2", 4, 14);
        public static ConstShipment Musketeer16         = new ConstShipment("Musketeer16", 4, 16);
        public static ConstShipment Dragoon8            = new ConstShipment("Dragoon8", 4, 16);
        public static ConstShipment OrganGun5           = new ConstShipment("OrganGun5", 4, 20);
        public static ConstShipment Doppelsoldner9      = new ConstShipment("Doppelsoldner9", 4, 18);
        public static ConstShipment Skirmisher14        = new ConstShipment("Skirmisher14", 4, 14);
        public static ConstShipment Skirmisher12        = new ConstShipment("Skirmisher12", 4, 12);
        public static ConstShipment Uhlan9              = new ConstShipment("Uhlan9", 4, 18);
        public static ConstShipment PolishWingedHussars = new ConstShipment("PolishWingedHussars", 4, 20);
        public static ConstShipment Ruyter17            = new ConstShipment("Ruyter17", 4, 17);
        public static ConstShipment CavalryArcher9      = new ConstShipment("CavalryArcher9", 4, 18);
        public static ConstShipment AbusGun12           = new ConstShipment("AbusGun12", 4, 24);
        public static ConstShipment Lancer7             = new ConstShipment("Lancer7", 4, 14);
        public static ConstShipment Lancer8             = new ConstShipment("Lancer8", 4, 16);
        public static ConstShipment Pikeman24           = new ConstShipment("Pikeman24", 4, 24);
        public static ConstShipment Cossack9            = new ConstShipment("Cossack9", 4, 9);

        //Asian
        public static ConstShipment OldHanReforms       = new ConstShipment("OldHanReforms", 4, 0, false, 1000);

        public static ConstShipment Urumi9              = new ConstShipment("Urumi9", 4, 18, true, 750);
        public static ConstShipment UrumiRegiment       = new ConstShipment("UrumiRegiment", 4, 22, false, 1000);
        public static ConstShipment Yumi16              = new ConstShipment("Yumi16", 4, 16, false, 0, 0, 0, true);
        public static ConstShipment FlamingArrow4       = new ConstShipment("FlamingArrow4", 4, 16, false, 0, 0, 0, true);
        public static ConstShipment ShogunTokugawa      = new ConstShipment("ShogunTokugawa", 4, 4);
        public static ConstShipment ChuKoNu21           = new ConstShipment("ChuKoNu21", 4, 21);
        public static ConstShipment QiangPikeman21      = new ConstShipment("QiangPikeman21", 4, 21);
        public static ConstShipment MeteorHammer8       = new ConstShipment("MeteorHammer8", 4, 16);
        public static ConstShipment ChangdaoSwordsman18 = new ConstShipment("ChangdaoSwordsman18", 4, 18);
        public static ConstShipment FlyingCrow2         = new ConstShipment("FlyingCrow2", 4, 14, true);

        //Native        
        public static ConstShipment Crates1800          = new ConstShipment("Crates1800", 4);
        public static ConstShipment Crates1500          = new ConstShipment("Crates1500", 4, 0, true);

        public static ConstShipment CoyoteRunner15      = new ConstShipment("CoyoteRunner15", 4, 15);
        public static ConstShipment Macehualtin20       = new ConstShipment("Macehualtin20", 4, 20, true);
        public static ConstShipment Macehualtin24       = new ConstShipment("Macehualtin24", 4, 24);
        public static ConstShipment SkullKnight7        = new ConstShipment("SkullKnight7", 4, 14);
        public static ConstShipment WakinaRifle18       = new ConstShipment("WakinaRifle18", 4, 18);
        public static ConstShipment AxeRider8           = new ConstShipment("AxeRider8", 4, 16);
        public static ConstShipment Tomahawk16          = new ConstShipment("Tomahawk16", 4, 16);
        public static ConstShipment LightCannon4        = new ConstShipment("LightCannon4", 4, 16);
    }
}
