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
        IRace Race { get; set; }
        int Level { get; }
        string CurrentClass { get; }
        Dictionary<string,IClass> CurrentClassDefinitions { get; set; }
    }
}
