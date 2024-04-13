using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Warlock : AbstractDDOClass
    {
        public Warlock(int level) : base(120, nameof(Warlock), level, "warlock.png") { }
        public Warlock() : this(MIN_CLASS_LEVEL) { }
    }
}
