using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public interface IIncarnation
    {
        int Id { get; }
        IRace Race { get; }
        int Level { get; }
        string CurrentClass { get; }
        List<IClass> CurrentClassDefinitions { get; }
        void AddClass(IClass classDefinition);
    }
}
