using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Incarnation : IIncarnation
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public IRace Race { get; set; }
        public int Level
        {
            get
            {
                return _currentClassDefinitions.Aggregate(0, (total, next) => total + next.Value.Level);
            }
        }

        public string CurrentClass
        {
            get
            {
                IEnumerable<string> levels = _currentClassDefinitions
                    .OrderByDescending(x => x.Value.Level)
                    .Select(x => $"{x.Value.Level} {x.Key}");
                return String.Join("/", levels);
            }
        }

        public IEnumerable<IClass> CurrentClassDefinitions { get { return _currentClassDefinitions.Values.AsEnumerable(); } }

        private Dictionary<string, IClass> _currentClassDefinitions;

        private const int MAX_CHARACTER_LEVEL = 20;
        private const int MAX_NUM_CLASSES = 3;

        public Incarnation(int characterId)
        {
            CharacterId = characterId;
            _currentClassDefinitions = new Dictionary<string, IClass>();
        }

        public Incarnation(int characterId, IRace race, IClass ddoClass, int id) : this(characterId, race, [ddoClass], id) {  }

        public Incarnation(int characterId, IRace race, IEnumerable<IClass> ddoClasses, int id) : this(characterId, race, ddoClasses)
        {
            Id = id;
        }

        public Incarnation(int characterId, IRace race, IClass ddoClass) : this(characterId, race, [ddoClass]) { }

        public Incarnation(int characterId, IRace race, IEnumerable<IClass> ddoClasses)
        {
            CharacterId = characterId;
            Race = race;
            _currentClassDefinitions = new Dictionary<string, IClass>();
            AddClasses(ddoClasses);
        }

        public void AddClasses(IEnumerable<IClass> classes)
        {
            foreach (IClass c in classes) 
            {
                AddClass(c);
            }
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
