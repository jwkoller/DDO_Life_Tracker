
namespace DDO_Life_Tracker.Services
{
    public static class Definitions
    {
        public enum DDOClasses
        {
            Alchemist = 101,
            Artificer = 102,
            Barbarian = 103,
            Dragon_Lord = 104,
            Fighter = 105,
            Monk = 106,
            Rogue = 107,
            Sorcerer = 108,
            Wizard = 109,
            Favored_Soul = 110,
            Bard = 111,
            Stormsinger = 112,
            Cleric = 113,
            Dark_Apostate = 114,
            Blightcaster = 115,
            Paladin = 116,
            Sacred_Fist = 117,
            Ranger = 118,
            Dark_Hunter = 119,
            Warlock = 120,
            Acolyte_of_the_Skin = 121,
            Druid = 122,
        }

        public static string[] AllDdoClasses
        { 
            get 
            {
                return Enum.GetNames<DDOClasses>();
            } 
        }
    }
}
