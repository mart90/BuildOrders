using System;
using System.Reflection;

namespace BuildOrders
{
    [Serializable]
    public static class cTech
    {
        public static ConstTech GetFieldByName(string name)
        {
            try
            { 
                return (ConstTech)typeof(cTech).GetField(name, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public).GetValue(null);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        //EU town center
        public static ConstTech Quartermaster           = new ConstTech("Quartermaster", 800, 0, 0, 90, 1);
        public static ConstTech PhilosophersPrince      = new ConstTech("PhilosophersPrince", 800, 0, 0, 90, 1);
        public static ConstTech Bishop                  = new ConstTech("Bishop", 800, 0, 0, 90, 1);
        public static ConstTech Governor                = new ConstTech("Governor", 800, 0, 0, 90, 1);
        public static ConstTech Marksman                = new ConstTech("Marksman", 1200, 0, 1000, 110, 2);
        public static ConstTech Adventurer              = new ConstTech("Adventurer", 1200, 0, 1000, 110, 2);
        public static ConstTech ExilePrince             = new ConstTech("ExilePrince", 1200, 0, 1000, 70, 2);
        public static ConstTech AdmiralOfOcean          = new ConstTech("AdmiralOfOcean", 1200, 0, 1000, 110, 2);
        public static ConstTech SergeantAtArms          = new ConstTech("SergeantOfArms", 1200, 0, 1000, 110, 2);
        public static ConstTech Scout                   = new ConstTech("Scout", 1200, 0, 1000, 110, 2);
        public static ConstTech Tycoon                  = new ConstTech("Tycoon", 2000, 0, 1200, 90, 3);
        public static ConstTech KingsMusketeer          = new ConstTech("KingsMusketeer", 2000, 0, 1200, 90, 3);
        public static ConstTech Engineer                = new ConstTech("Engineer", 2000, 0, 1200, 90, 3);
        public static ConstTech Viceroy                 = new ConstTech("Viceroy", 2000, 0, 1200, 90, 3);
        public static ConstTech CavalryMarshal          = new ConstTech("CavalryMarshal", 2000, 0, 1200, 90, 3);
        public static ConstTech GrandVizier             = new ConstTech("GrandVizier", 2000, 0, 1200, 90, 3);
        public static ConstTech WarMinister             = new ConstTech("WarMinister", 2000, 0, 1200, 90, 3);

        //Native town center
        public static ConstTech WiseWoman               = new ConstTech("WiseWoman", 0, 0, 0, 90, 1);
        public static ConstTech Warrior                 = new ConstTech("Warrior", 0, 0, 0, 90, 1);
        public static ConstTech Shaman                  = new ConstTech("Shaman", 0, 0, 0, 90, 1);
        public static ConstTech Messenger               = new ConstTech("Messenger", 0, 0, 0, 90, 1);
        public static ConstTech Chief                   = new ConstTech("Chief", 0, 0, 0, 90, 1);

        //EU market
        public static ConstTech HuntingDogs             = new ConstTech("HuntingDogs", 0, 50, 50, 20, 1);
        public static ConstTech SteelTraps              = new ConstTech("SteelTraps", 0, 125, 125, 30, 2);
        public static ConstTech GangSaw                 = new ConstTech("GangSaw", 100, 0, 0, 30, 1);
        public static ConstTech LogFlume                = new ConstTech("LogFlume", 150, 0, 250, 30, 2);
        public static ConstTech CircularSaw             = new ConstTech("CircularSaw", 240, 0, 480, 30, 3);
        public static ConstTech PlacerMines             = new ConstTech("PlacerMines", 75, 75, 0, 30, 1);
        public static ConstTech Amalgamation            = new ConstTech("Amalgamation", 200, 200, 0, 30, 2);

        //Native market
        public static ConstTech LumberCeremony          = new ConstTech("LumberCeremony", 100, 0, 150, 30, 1);
        public static ConstTech ForestPeopleCeremony    = new ConstTech("ForestPeopleCeremony", 235, 0, 150, 30, 2);
        public static ConstTech ForestSpiritCeremony    = new ConstTech("ForestSpiritCeremony", 400, 0, 250, 30, 3);

        //Asian market
        public static ConstTech HuntingEagles           = new ConstTech("HuntingEagles", 0, 25, 25, 10, 1);
        public static ConstTech ProfessionalHunters     = new ConstTech("ProfessionalHunters", 0, 65, 65, 15, 2);
        public static ConstTech HanamiParties           = new ConstTech("HanamiParties", 0, 25, 25, 10, 1);
        public static ConstTech YozakuraLanterns        = new ConstTech("YozakuraLanterns", 0, 65, 65, 15, 2);
        public static ConstTech WaterWheel              = new ConstTech("WaterWheel", 50, 0, 0, 15, 1);
        public static ConstTech RegenerativeForestry    = new ConstTech("RegenerativeForestry", 75, 0, 75, 15, 2);
        public static ConstTech TimberTrade             = new ConstTech("TimberTrade", 240, 0, 480, 30, 3);
        public static ConstTech BlanketFilters          = new ConstTech("BlanketFilters", 40, 40, 0, 10, 1);
        public static ConstTech FlumeAndDitching        = new ConstTech("FlumeAndDitching", 100, 100, 0, 15, 2);
        public static ConstTech CivilServants           = new ConstTech("CivilServants", 50, 50, 50, 30, 1);
        public static ConstTech ImperialBureaucracy     = new ConstTech("ImperialBureaucracy", 150, 150, 150, 30, 2);

        //EU Military
        public static ConstTech VeteranHussar           = new ConstTech("VeteranHussar", 0, 200, 200, 20, 2);

        //Consulate
        public static ConstTech CancelAlliance          = new ConstTech("CancelAlliance", 0, 0, 0, 60, 1, 0);
        public static ConstTech AllyPortuguese          = new ConstTech("AllyPortuguese", 0, 0, 0, 10, 1, 100);
        public static ConstTech AllyBritish             = new ConstTech("AllyBritish", 0, 0, 0, 10, 1, 100);
        public static ConstTech AllyOttomans            = new ConstTech("AllyOttomans", 0, 0, 0, 10, 1, 100);
        public static ConstTech AllyFrench              = new ConstTech("AllyFrench", 0, 0, 0, 10, 1, 100);
        public static ConstTech AllyJapanese            = new ConstTech("AllyPortuguese", 0, 0, 0, 10, 1, 100);
        public static ConstTech AllyDutch               = new ConstTech("AllyBritish", 0, 0, 0, 10, 1, 100);
        public static ConstTech AllySpanish             = new ConstTech("AllyOttomans", 0, 0, 0, 10, 1, 100);
        public static ConstTech AllyGermans             = new ConstTech("AllyGermans", 0, 0, 0, 10, 1, 100);
        public static ConstTech AllyRussians            = new ConstTech("AllyRussians", 0, 0, 0, 10, 1, 100);

        public static ConstTech Crates500w              = new ConstTech("Crates500w", 0, 0, 0, 30, 2, 300);
        public static ConstTech Crates500c              = new ConstTech("Crates500c", 0, 0, 0, 30, 2, 300);
        public static ConstTech Crates500f              = new ConstTech("Crates500f", 0, 0, 0, 30, 2, 300);
        public static ConstTech Vills4                  = new ConstTech("Vills4", 0, 0, 0, 30, 2, 300);
        public static ConstTech FishingFleet            = new ConstTech("FishingFleet", 0, 0, 0, 30, 2, 250);
        public static ConstTech BankWagon               = new ConstTech("BankWagon", 0, 0, 0, 30, 2, 450);

        public static ConstTech PortugueseExpeditionaryCompany  = new ConstTech("PortugueseExpeditionaryCompany", 0, 0, 0, 20, 2, 400);
        public static ConstTech PortugueseExpeditionaryForce    = new ConstTech("PortugueseExpeditionaryForce", 0, 0, 0, 40, 3, 800);
        public static ConstTech DutchExpeditionaryCompany       = new ConstTech("DutchExpeditionaryCompany", 0, 0, 0, 20, 2, 400);
        public static ConstTech DutchExpeditionaryForce         = new ConstTech("DutchExpeditionaryForce", 0, 0, 0, 40, 3, 800);
        public static ConstTech SpanishExpeditionaryCompany     = new ConstTech("SpanishExpeditionaryCompany", 0, 0, 0, 20, 2, 400);
        public static ConstTech SpanishExpeditionaryForce       = new ConstTech("SpanishExpeditionaryForce", 0, 0, 0, 40, 3, 800);
        public static ConstTech BritishExpeditionaryCompany     = new ConstTech("BritishExpeditionaryCompany", 0, 0, 0, 20, 2, 400);
        public static ConstTech BritishExpeditionaryForce       = new ConstTech("BritishExpeditionaryForce", 0, 0, 0, 40, 3, 800);
        public static ConstTech OttomanExpeditionaryCompany     = new ConstTech("OttomanExpeditionaryCompany", 0, 0, 0, 20, 2, 400);
        public static ConstTech OttomanExpeditionaryForce       = new ConstTech("OttomanExpeditionaryForce", 0, 0, 0, 40, 3, 800);
        public static ConstTech GermanExpeditionaryCompany      = new ConstTech("GermanExpeditionaryCompany", 0, 0, 0, 20, 2, 400);
        public static ConstTech GermanExpeditionaryForce        = new ConstTech("GermanExpeditionaryForce", 0, 0, 0, 40, 3, 800);
        public static ConstTech RussianExpeditionaryCompany     = new ConstTech("RussianExpeditionaryCompany", 0, 0, 0, 20, 2, 400);
        public static ConstTech RussianExpeditionaryForce       = new ConstTech("RussianExpeditionaryForce", 0, 0, 0, 40, 3, 800);

        //Church
        public static ConstTech MilletSystem            = new ConstTech("MilletSystem", 0, 100, 0, 15, 1);
        public static ConstTech KopruluViziers          = new ConstTech("KopruluViziers", 0, 250, 0, 15, 2);
        public static ConstTech AbbassidMarket          = new ConstTech("AbbassidMarket", 0, 600, 0, 15, 2);
        public static ConstTech Topkapi                 = new ConstTech("Topkapi", 0, 400, 400, 15, 3);
        public static ConstTech GalataTowerDistrict     = new ConstTech("GalataTowerDistrict", 0, 0, 200, 15, 2);
        public static ConstTech Tanzimat                = new ConstTech("Tanzimat", 400, 400, 400, 15, 4);

        //Trading post
        public static ConstTech StageCoach              = new ConstTech("StageCoach", 200, 200, 0, 60, 2);

        //Factory
        public static ConstTech Cannery                 = new ConstTech("Cannery", 0, 250, 250, 30, 4);
        public static ConstTech WaterPower              = new ConstTech("WaterPower", 250, 0, 250, 30, 4);
        public static ConstTech SteamPower              = new ConstTech("SteamPower", 250, 250, 0, 30, 4);
        public static ConstTech MassProduction          = new ConstTech("MassProduction", 300, 0, 300, 30, 4);
    }
}
