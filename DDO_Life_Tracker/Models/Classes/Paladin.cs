using DDO_Life_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Paladin : AbstractDDOClass
    {
        public Paladin(int level) : base((int)DDOClasses.Paladin, nameof(Paladin), level, "paladin.png") { }
        public Paladin() : this(MIN_CLASS_LEVEL) { }
    }
}
