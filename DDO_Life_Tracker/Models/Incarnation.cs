using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Incarnation : IIncarnation
    {
        public int Id { get; }
        public IRace Race { get; set; }
        public int Level
        {
            get
            {
                return CurrentClassDefinitions.Aggregate(0, (total, next) => total + next.Value.Level);
            }
        }

        public string CurrentClass
        {
            get
            {
                IEnumerable<string> levels = CurrentClassDefinitions.Select(x => $"{x.Value.Level} {x.Key}");
                return String.Join( "/", levels);
            }
        }

        public Dictionary<string,IClass> CurrentClassDefinitions { get; set; }

        public Incarnation(IRace race, IClass ddoClass) : this(race, new Dictionary<string, IClass> { { nameof(ddoClass), ddoClass } }) { }

        public Incarnation(IRace race, Dictionary<string, IClass> ddoClasses ) 
        {
            //TODO set the ID
            //Id = ??
            Race = race;
            CurrentClassDefinitions = ddoClasses;
        }

    }
}
