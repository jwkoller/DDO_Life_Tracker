using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models.Races
{
    public class Human : IRace
    {
        public int Id { get; }
        public string Name { get; }
        public bool IsIconic { get; }

        public Human() 
        {
            Id = 101;
            Name = nameof(Human);
            IsIconic = false;
        }
    }
}
