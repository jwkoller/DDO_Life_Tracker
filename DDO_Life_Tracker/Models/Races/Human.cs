using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Human : AbstractDDORace
    {
        public Human() : base(101, nameof(Human), "human.png") { }
    }
}
