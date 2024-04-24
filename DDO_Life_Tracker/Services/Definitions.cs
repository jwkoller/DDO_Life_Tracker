
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

        public static IClass IdToDDOClass(int id)
        {
            IClass classType = id switch
            {
                (int)DDOClasses.Acolyte_of_the_Skin => new Acolyte_of_the_Skin(),
                (int)DDOClasses.Alchemist => new Alchemist(),
                (int)DDOClasses.Artificer => new Artificer(),
                (int)DDOClasses.Barbarian => new Barbarian(),
                (int)DDOClasses.Bard => new Bard(),
                (int)DDOClasses.Blightcaster => new Blightcaster(),
                (int)DDOClasses.Cleric => new Cleric(),
                (int)DDOClasses.Dark_Apostate => new Dark_Apostate(),
                (int)DDOClasses.Dark_Hunter => new Dark_Hunter(),
                (int)DDOClasses.Dragon_Lord => new Dragon_Lord(),
                (int)DDOClasses.Druid => new Druid(),
                (int)DDOClasses.Favored_Soul => new Favored_Soul(),
                (int)DDOClasses.Fighter => new Fighter(),
                (int)DDOClasses.Monk => new Monk(),
                (int)DDOClasses.Paladin => new Paladin(),
                (int)DDOClasses.Ranger => new Ranger(),
                (int)DDOClasses.Rogue => new Rogue(),
                (int)DDOClasses.Sacred_Fist => new Sacred_Fist(),
                (int)DDOClasses.Sorcerer => new Sorcerer(),
                (int)DDOClasses.Stormsinger => new Stormsinger(),
                (int)DDOClasses.Warlock => new Warlock(),
                (int)DDOClasses.Wizard => new Wizard(),
                _ => throw new Exception($"Class ID {id} does not match any classes"),
            };
            return classType;
        }

        public static IRace IdToDDORace(int id)
        {
            IRace raceType = id switch
            {
                (int)DDORaces.Aasimar => new Aasimar(),
                (int)DDORaces.Aasimar_Scourge => new Aasimar_Scourge(),
                (int)DDORaces.Bladforged => new Bladeforged(),
                (int)DDORaces.Deep_Gnome => new Deep_Gnome(),
                (int)DDORaces.Dragonborn => new Dragonborn(),
                (int)DDORaces.Drow => new Drow(),
                (int)DDORaces.Dwarf => new Dwarf(),
                (int)DDORaces.Elf => new Elf(),
                (int)DDORaces.Gnome => new Gnome(),
                (int)DDORaces.Halfling => new Halfling(),
                (int)DDORaces.Half__Elf => new Half_Elf(),
                (int)DDORaces.Half__Orc => new Half_Orc(),
                (int)DDORaces.Human => new Human(),
                (int)DDORaces.Morninglord => new Morninglord(),
                (int)DDORaces.Purple_Dragon_Knight => new Purple_Dragon_Knight(),
                (int)DDORaces.Razorclaw_Shifter => new Razorclaw_Shifter(),
                (int)DDORaces.Shadar__Kai => new Shadar_Kai(),
                (int)DDORaces.Shifter => new Shifter(),
                (int)DDORaces.Tabaxi => new Tabaxi(),
                (int)DDORaces.Tabaxi_Trailblazer => new Tabaxi_Trailblazer(),
                (int)DDORaces.Tiefling => new Tiefling(),
                (int)DDORaces.Tiefling_Scoundrel => new Tiefling_Scoundrel(),
                (int)DDORaces.Warforged => new Warforged(),
                (int)DDORaces.Wood_Elf => new Wood_Elf(),
                _ => throw new Exception($"Race ID {id} does not match any races"),
            };
            return raceType;
        }
    }
}
