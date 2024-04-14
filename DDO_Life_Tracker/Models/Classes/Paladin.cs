using DDO_Life_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Paladin : AbstractDDOClass
    {
        public Paladin(int level) : base(106, nameof(Paladin), level, "paladin.png") { }
        public Paladin() : this(MIN_CLASS_LEVEL) { }
    }
}
