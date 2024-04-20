using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Services
{
    public static class Definitions
    {
        public enum DDOClasses
        {
            Alchemist,
            Artificer,
            Barbarian,
            Dragon_Lord,
            Fighter,
            Monk,
            Rogue,
            Sorcerer,
            Wizard,
            Favored_Soul,
            Bard,
            Stormsinger,
            Cleric,
            Dark_Apostate,
            Druid,
            Blightcaster,
            Paladin,
            Sacred_Fist,
            Ranger,
            Dark_Hunter,
            Warlock,
            Acolyte_of_the_Skin
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
