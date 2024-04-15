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
        public IRace Race { get; }
        public int Level
        {
            get
            {
                return CurrentClassDefinitions.Aggregate(0, (total, next) => total + next.Level);
            }
        }

        public string CurrentClass
        {
            get
            {
                IEnumerable<string> levels = CurrentClassDefinitions.Select(x => $"{x.Level} {x.Name}");
                return String.Join( "/", levels);
            }
        }

        public List<IClass> CurrentClassDefinitions { get; }

        public Incarnation(IRace race, IClass ddoClass) : this(race, new List<IClass> { ddoClass }) { }

        public Incarnation(IRace race, List<IClass> ddoClasses ) 
        {
            //TODO set the ID
            //Id = ??
            Race = race;
            CurrentClassDefinitions = ddoClasses;
        }

        public void AddClass(IClass classToAdd)
        {
            CurrentClassDefinitions.Add(classToAdd);
        }
    }
}
