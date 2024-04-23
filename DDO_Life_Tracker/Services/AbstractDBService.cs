using DDO_Life_Tracker.Models;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Services
{
    public abstract class AbstractDBService<T, K> : IDBService<T, K>
    {
        public abstract T DataToModel(K data);

        public abstract K ModelToData(T model);

        public IClass IdToDDOClass(int id)
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
        
        public IRace IdToDDORace(int id)
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
