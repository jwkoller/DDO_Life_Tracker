using DDO_Life_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Rogue : AbstractDDOClass
    {
        public Rogue(int level) : base(104, nameof(Rogue), level, "rogue.png") { }
        public Rogue() : this(MIN_CLASS_LEVEL) { }
    }
}
