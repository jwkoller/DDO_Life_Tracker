using DDO_Life_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Rogue : AbstractDDOClass
    {
        public Rogue(int level) : base((int)DDOClasses.Rogue, nameof(Rogue), level, "rogue.png") { }
        public Rogue() : this(MIN_CLASS_LEVEL) { }
    }
}
