using System;
using System.Reflection;

namespace BuildOrders
{
    [Serializable]
    public static class cUnit
    {
        public static ConstUnit GetFieldByName(string name)
        {
            try
            {
                return (ConstUnit)typeof(cUnit).GetField(name, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public).GetValue(null);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        //ECONOMIC
        public static ConstUnit Villager                = new ConstUnit("Villager", 100, 0, 0, 1, 25, 1, 10);
        public static ConstUnit DutchVillager           = new ConstUnit("Villager", 0, 0, 100, 1, 25, 1, 10);
        public static ConstUnit IndianVillager          = new ConstUnit("Villager", 0, 100, 0, 1, 25, 1, 10);
        public static ConstUnit Coureur                 = new ConstUnit("Villager", 125, 0, 0, 1, 29, 1, 12);
        public static ConstUnit FishingBoat             = new ConstUnit("FishingBoat", 0, 70, 0, 1, 25, 1, 7);

        //INFANTRY
        //EU
        public static ConstUnit Crossbowman             = new ConstUnit("Crossbowman", 40, 40, 0, 1, 27, 2, 8);
        public static ConstUnit Musketeer               = new ConstUnit("Musketeer", 75, 0, 25, 1, 30, 2, 10);
        public static ConstUnit Longbowman              = new ConstUnit("Longbowman", 60, 40, 0, 1, 30, 2, 10);
        public static ConstUnit Pikeman                 = new ConstUnit("Pikeman", 40, 40, 0, 1, 27, 2, 8);
        public static ConstUnit Skirmisher              = new ConstUnit("Skirmisher", 50, 0, 65, 1, 33, 3, 12);
        public static ConstUnit Cassadore               = new ConstUnit("Cassadore", 80, 0, 35, 1, 33, 3, 12);
        public static ConstUnit Doppelsoldner           = new ConstUnit("Doppelsoldner", 75, 0, 125, 2, 45, 2, 20);
        public static ConstUnit Janissary               = new ConstUnit("Janissary", 90, 0, 25, 1, 34, 2, 12);
        public static ConstUnit Halberdier              = new ConstUnit("Halberdier", 50, 0, 70, 1, 33, 3, 13);
        public static ConstUnit Rodelero                = new ConstUnit("Rodelero", 65, 0, 35, 1, 30, 2, 10);
        public static ConstUnit Strelet                 = new ConstUnit("Strelet", 0, 0, 0, 1, 0, 2, 0);

        //Native
        public static ConstUnit Macehualtin             = new ConstUnit("Macehualtin", 40, 30, 0, 1, 23, 2, 7);
        public static ConstUnit CoyoteRunner            = new ConstUnit("CoyoteRunner", 85, 25, 0, 1, 27, 2, 11);
        public static ConstUnit PumaSpearman            = new ConstUnit("PumaSpearman", 50, 0, 50, 1, 30, 2, 10);
        public static ConstUnit EagleRunnerKnight       = new ConstUnit("EagleRunnerKnight", 75, 0, 75, 1, 37, 3, 15);
        public static ConstUnit ArrowKnight             = new ConstUnit("ArrowKnight", 50, 0, 75, 2, 34, 3, 13);
        public static ConstUnit JaguarProwlKnight       = new ConstUnit("JaguarProwlKnight", 120, 0, 30, 1, 37, 3, 15);
        public static ConstUnit SkullKnight             = new ConstUnit("SkullKnight", 0, 0, 0, 2, 0, 0, 0);
        public static ConstUnit CetanBow                = new ConstUnit("CetanBow", 65, 35, 0, 1, 30, 2, 10);
        public static ConstUnit WarClub                 = new ConstUnit("WarClub", 50, 40, 0, 1, 29, 2, 9);
        public static ConstUnit WakinaRifle             = new ConstUnit("WakinaRifle", 60, 0, 40, 1, 29, 3, 10);
        public static ConstUnit Tomahawk                = new ConstUnit("Tomahawk", 75, 25, 0, 1, 30, 2, 10);
        public static ConstUnit Aenna                   = new ConstUnit("Aenna", 100, 0, 0, 1, 27, 2, 10);
        public static ConstUnit ForestProwler           = new ConstUnit("ForestProwler", 50, 0, 65, 1, 33, 3, 12);

        //Asian
        public static ConstUnit Gurkha                  = new ConstUnit("Gurkha", 70, 0, 50, 1, 33, 2, 12);
        public static ConstUnit Sepoy                   = new ConstUnit("Sepoy", 90, 0, 30, 1, 34, 2, 12);
        public static ConstUnit Urumi                   = new ConstUnit("Urumi", 0, 0, 0, 2, 0, 3, 0);
        public static ConstUnit Yumi                    = new ConstUnit("Yumi", 55, 50, 0, 1, 28, 2, 11);
        public static ConstUnit Ashigaru                = new ConstUnit("Ashigaru", 80, 0, 40, 1, 33, 2, 12);
        public static ConstUnit Samurai                 = new ConstUnit("Samurai", 100, 0, 100, 2, 45, 2, 20);
        public static ConstUnit Disciple                = new ConstUnit("Disciple", 80, 0, 0, 0, 11, 1, 8);
        public static ConstUnit ChuKoNu                 = new ConstUnit("ChuKoNu", 0, 0, 0, 0, 0, 0, 0);
        public static ConstUnit QiangPikeman            = new ConstUnit("QiangPikeman", 0, 0, 0, 0, 0, 0, 0);
        public static ConstUnit Arquebusier             = new ConstUnit("Arquebusier", 0, 0, 0, 0, 0, 0, 0);
        public static ConstUnit ChangdaoSwordsman       = new ConstUnit("ChangdaoSwordsman", 0, 0, 0, 0, 0, 0, 0);
        //Consulate
        public static ConstUnit RedcoatMusketeer        = new ConstUnit("RedcoatMusketeer", 0, 0, 0, 1, 0, 2, 0);
        public static ConstUnit StadhouderMusketeer     = new ConstUnit("StadhouderMusketeer", 0, 0, 0, 1, 0, 2, 0);
        public static ConstUnit YoungGardeGrenadier     = new ConstUnit("YoungGardeGrenadier", 0, 0, 0, 2, 0, 2, 0);
        public static ConstUnit ZweihanderDoppelsoldner = new ConstUnit("ZweihanderDoppelsoldner", 0, 0, 0, 2, 0, 2, 0);
        public static ConstUnit PrussianNeedleGun       = new ConstUnit("PrussianNeedleGun", 0, 0, 0, 2, 0, 2, 0);
        public static ConstUnit KonshaYamabushi         = new ConstUnit("KonshaYamabushi", 0, 0, 0, 1, 30, 2, 6, 60);
        public static ConstUnit ShinobiNoMono           = new ConstUnit("ShinobiNoMono", 0, 0, 0, 1, 30, 2, 8, 80);
        public static ConstUnit BesteiroCrossbow        = new ConstUnit("BesteiroCrossbow", 0, 0, 0, 1, 0, 2, 0);
        public static ConstUnit TercioPikeman           = new ConstUnit("TercioPikeman", 0, 0, 0, 1, 0, 2, 0);

        //Mercenary
        public static ConstUnit SwissPikeman            = new ConstUnit("SwissPikeman", 0, 0, 0, 0, 0, 0, 0);
        public static ConstUnit Jaeger                  = new ConstUnit("Jaeger", 0, 0, 0, 0, 0, 0, 0);
        public static ConstUnit Highlander              = new ConstUnit("Highlander", 0, 0, 0, 0, 0, 0, 0);

        //CAVALRY
        //EU
        public static ConstUnit Hussar                  = new ConstUnit("Hussar", 120, 0, 80, 2, 40, 2, 20);
        public static ConstUnit Dragoon                 = new ConstUnit("Dragoon", 90, 0, 90, 2, 38, 3, 18);
        public static ConstUnit Cuirassier              = new ConstUnit("Cuirassier", 150, 0, 150, 3, 60, 3, 30);
        public static ConstUnit Uhlan                   = new ConstUnit("Uhlan", 50, 0, 100, 2, 35, 2, 15);
        public static ConstUnit CavalryArcher           = new ConstUnit("CavalryArcher", 100, 0, 60, 2, 36, 3, 16);
        public static ConstUnit Cossack                 = new ConstUnit("Cossack", 75, 0, 75, 1, 35, 2, 15);
        public static ConstUnit Oprichnik               = new ConstUnit("Oprichnik", 90, 0, 60, 2, 40, 3, 15);
        public static ConstUnit WarWagon                = new ConstUnit("WarWagon", 150, 0, 150, 3, 60, 3, 30);
        public static ConstUnit Lancer                  = new ConstUnit("Lancer", 110, 0, 90, 2, 40, 3, 20);
        public static ConstUnit Ruyter                  = new ConstUnit("Ruyter", 30, 0, 75, 1, 31, 3, 11);
        public static ConstUnit WingedHussar            = new ConstUnit("WingedHussar", 0, 0, 0, 2, 0, 4, 0);
        public static ConstUnit Spahi                   = new ConstUnit("Spahi", 0, 0, 0, 3, 0, 3, 0);

        //Native
        public static ConstUnit AxeRider                = new ConstUnit("AxeRider", 160, 0, 40, 2, 40, 2, 20);
        public static ConstUnit BowRider                = new ConstUnit("BowRider", 100, 0, 75, 2, 40, 2, 18);
        public static ConstUnit RifleRider              = new ConstUnit("RifleRider", 120, 0, 100, 2, 42, 3, 22);
        public static ConstUnit DogSoldier              = new ConstUnit("DogSoldier", 0, 0, 0, 3, 0, 1, 0);
        public static ConstUnit MusketRider             = new ConstUnit("MusketRider", 55, 0, 100, 2, 35, 3, 16);
        public static ConstUnit KanyaHorseman           = new ConstUnit("KanyaHorseman", 100, 75, 0, 2, 37, 2, 18);
        
        //Asian
        public static ConstUnit Sowar                   = new ConstUnit("Sowar", 80, 0, 80, 2, 35, 2, 16);
        public static ConstUnit Zamburak                = new ConstUnit("Zamburak", 60, 0, 60, 1, 33, 2, 12);
        public static ConstUnit Mahout                  = new ConstUnit("Mahout", 400, 250, 0, 7, 60, 3, 65);
        public static ConstUnit Howdah                  = new ConstUnit("Howdah", 250, 0, 350, 6, 60, 3, 60);
        public static ConstUnit Naginata                = new ConstUnit("Naginata", 100, 0, 100, 2, 40, 2, 20);
        public static ConstUnit Yabusame                = new ConstUnit("Yabusame", 60, 0, 150, 2, 40, 3, 21);
        public static ConstUnit DaimyoMototada          = new ConstUnit("DaimyoMototada", 0, 0, 350, 4, 90, 2, 35);
        public static ConstUnit DaimyoKiyomasa          = new ConstUnit("DaimyoKiyomasa", 0, 0, 350, 4, 90, 3, 35);
        public static ConstUnit ShogunTokugawa          = new ConstUnit("ShogunTokugawa", 0, 0, 350, 4, 90, 4, 35);
        public static ConstUnit DaimyoMasamune          = new ConstUnit("DaimyoMasamune", 0, 0, 350, 4, 90, 1, 35);
        public static ConstUnit SteppeRider             = new ConstUnit("SteppeRider", 0, 0, 0, 0, 0, 0, 0);
        public static ConstUnit Keshik                  = new ConstUnit("Keshik", 0, 0, 0, 0, 0, 0, 0);
        public static ConstUnit MeteorHammer            = new ConstUnit("MeteorHammer", 0, 0, 0, 0, 0, 0, 0);
        public static ConstUnit IronFlail               = new ConstUnit("IronFlail", 0, 0, 0, 0, 0, 0, 0);
        //Consulate
        public static ConstUnit GardenerHussar          = new ConstUnit("GardenerHussar", 0, 0, 0, 2, 0, 2, 0);
        public static ConstUnit SiberianCossack         = new ConstUnit("SiberianCossack", 0, 0, 0, 1, 0, 2, 0);
        public static ConstUnit Carabineer              = new ConstUnit("Carabineer", 0, 0, 0, 1, 0, 3, 0);

        //Mercenary
        public static ConstUnit BlackRider              = new ConstUnit("BlackRider", 0, 0, 0, 0, 0, 0, 0);
        public static ConstUnit Manchu                  = new ConstUnit("Manchu", 0, 0, 0, 0, 0, 0, 0);
        public static ConstUnit Mameluke                = new ConstUnit("Mameluke", 0, 0, 0, 0, 0, 0, 0);

        //ARTILLERY
        //EU
        public static ConstUnit Grenadier               = new ConstUnit("Grenadier", 120, 0, 60, 2, 42, 2, 18);
        public static ConstUnit Falconet                = new ConstUnit("Falconet", 0, 100, 400, 4, 45, 3, 50);
        public static ConstUnit Culverin                = new ConstUnit("Culverin", 0, 100, 400, 4, 45, 3, 50);
        public static ConstUnit Rocket                  = new ConstUnit("Rocket", 0, 0, 0, 6, 98, 4, 0);
        public static ConstUnit HeavyCannon             = new ConstUnit("HeavyCannon", 0, 0, 0, 7, 115, 4, 0);
        public static ConstUnit OrganGun                = new ConstUnit("OrganGun", 0, 100, 300, 4, 45, 3, 40);
        public static ConstUnit AbusGun                 = new ConstUnit("AbusGun", 50, 0, 100, 2, 42, 2, 15);

        //Asian
        public static ConstUnit SiegeElephant           = new ConstUnit("SiegeElephant", 0, 300, 400, 7, 45, 3, 70);
        public static ConstUnit FlamingArrow            = new ConstUnit("FlamingArrow", 0, 100, 300, 4, 38, 3, 40);
        public static ConstUnit HandMortar              = new ConstUnit("HandMortar", 50, 90, 0, 1, 30, 3, 14);
        public static ConstUnit FlyingCrow              = new ConstUnit("FlyingCrow", 0, 0, 0, 0, 0, 0, 0);

        //Native
        public static ConstUnit Mantlet                 = new ConstUnit("Mantlet", 0, 75, 125, 2, 45, 3, 20);
        public static ConstUnit LightCannon             = new ConstUnit("LightCannon", 0, 100, 300, 4, 45, 4, 40);

        //BATCHES
        //Russian
        public static ConstUnit VillagerBatch           = new ConstUnit("VillagerBatch", 270, 0, 0, 3, 53, 1, 30);
        public static ConstUnit StreletBatch            = new ConstUnit("StreletBatch", 375, 100, 0, 10, 30, 2, 60);
        public static ConstUnit MusketeerBatch          = new ConstUnit("MusketeerBatch", 281, 0, 93, 5, 23, 2, 50);
        public static ConstUnit HalberdierBatch         = new ConstUnit("HalberdierBatch", 150, 0, 210, 4, 25, 3, 48);

        //Chinese
        public static ConstUnit OldHanArmy              = new ConstUnit("OldHanArmy", 255, 180, 0, 6, 25, 2, 43);
        public static ConstUnit OldHanArmyReformed      = new ConstUnit("OldHanArmy", 318, 225, 0, 6, 25, 2, 43);
        public static ConstUnit StandardArmy            = new ConstUnit("StandardArmy", 255, 0, 170, 5, 25, 2, 42);
        public static ConstUnit StandardArmyReformed    = new ConstUnit("StandardArmy", 318, 0, 170, 5, 25, 2, 42);
        public static ConstUnit MingArmy                = new ConstUnit("MingArmy", 345, 120, 0, 5, 25, 2, 47);
        public static ConstUnit MingArmyReformed        = new ConstUnit("MingArmy", 345, 150, 0, 5, 25, 2, 47);
        public static ConstUnit TerritorialArmy         = new ConstUnit("TerritorialArmy", 285, 0, 255, 6, 33, 3, 54);
        public static ConstUnit ForbiddenArmy           = new ConstUnit("ForbiddenArmy", 480, 0, 350, 8, 33, 3, 83);
        public static ConstUnit ImperialArmy            = new ConstUnit("ImperialArmy", 480, 0, 255, 7, 33, 3, 74);
    }
}
