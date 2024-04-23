
using DDO_Life_Tracker.Models;

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

        public enum DDORaces
        {
            Aasimar = 101,
            Dragonborn = 102,
            Drow = 103,
            Dwarf = 104,
            Elf = 105,
            Gnome = 106,
            Halfling = 107,
            Half__Elf = 108, // double underscores replaced with hyphen
            Half__Orc = 109,
            Human = 110,
            Tiefling = 111,
            Warforged = 112,
            Wood_Elf = 113,
            Shifter = 114,
            Tabaxi = 115,
            Bladforged = 116,
            Deep_Gnome = 117,
            Morninglord = 118,
            Purple_Dragon_Knight = 119,
            Razorclaw_Shifter = 120,
            Tiefling_Scoundrel = 121,
            Aasimar_Scourge = 122,
            Shadar__Kai = 123,
            Tabaxi_Trailblazer = 124
        }

        public static string[] AllDdoRaces
        {
            get
            {
                return Enum.GetNames<DDORaces>();
            }
        }
    }
}
