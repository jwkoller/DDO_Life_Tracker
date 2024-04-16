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
                return String.Join("/", levels);
            }
        }

        public IEnumerable<IClass> CurrentClassDefinitions { get { return _currentClassDefinitions.Values.AsEnumerable(); } }

        private Dictionary<string, IClass> _currentClassDefinitions;

        private const int MAX_CHARACTER_LEVEL = 20;

        public Incarnation(IRace race, IClass ddoClass) : this(race, [ddoClass]) { }

        public Incarnation(IRace race, IEnumerable<IClass> ddoClasses ) 
        {
            //TODO set the ID
            //Id = ??
            Race = race;
            _currentClassDefinitions = ddoClasses.ToDictionary(x => x.Name);
        }

        public void AddClass(IClass classToAdd)
        {
            int newTotal = Level + classToAdd.Level;
            if (newTotal >  MAX_CHARACTER_LEVEL)
            {
                throw new Exception($"New total character level {newTotal} is greater than max {MAX_CHARACTER_LEVEL}.");
            }

            if (_currentClassDefinitions.ContainsKey(classToAdd.Name))
            {
                _currentClassDefinitions[classToAdd.Name].Level += classToAdd.Level;
            }
            else
            {
                _currentClassDefinitions.Add(classToAdd.Name, classToAdd);
            }
        }
    }
}
