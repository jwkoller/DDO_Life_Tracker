using DDO_Life_Tracker.Services;
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
                IEnumerable<string> levels = _currentClassDefinitions.Select(x => $"{x.Value.Level} {x.Key}");
                return String.Join("/", levels);
            }
        }

        public IEnumerable<IClass> CurrentClassDefinitions { get { return _currentClassDefinitions.Values.AsEnumerable(); } }

        private Dictionary<string, IClass> _currentClassDefinitions;

        private const int MAX_CHARACTER_LEVEL = Definitions.MAX_CHARACTER_LEVEL;
        private const int MAX_NUM_CLASSES = Definitions.MAX_NUM_CLASSES;

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
            if (_currentClassDefinitions.Keys.Count == MAX_NUM_CLASSES)
            {
                throw new Exception($"Character already has max number of classes ({MAX_NUM_CLASSES})");
            }

            if (_currentClassDefinitions.ContainsKey(classToAdd.Name))
            {
                throw new Exception($"Character already has levels in {classToAdd.Name}");
            }

            int newTotal = Level + classToAdd.Level;
            if (newTotal >  MAX_CHARACTER_LEVEL)
            {
                throw new Exception($"New total character level {newTotal} is greater than max {MAX_CHARACTER_LEVEL}.");
            }

            _currentClassDefinitions.Add(classToAdd.Name, classToAdd);
        }

        public void IncrementClassLevel(string classNameToIncrement)
        {
            _currentClassDefinitions[classNameToIncrement].Level++;
        }
    }
}
