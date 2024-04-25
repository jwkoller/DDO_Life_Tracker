using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public interface IIncarnation
    {
        int Id { get; set; }
        int CharacterId { get; set; }
        IRace Race { get; set; }
        int Level { get; }
        string CurrentClass { get; }
        IEnumerable<IClass> CurrentClassDefinitions { get; }
        void AddClass(IClass classDefinition);
        void AddClasses(IEnumerable<IClass> classes);
        void IncrementClassLevel(string classNameToIncrement);
    }
}
