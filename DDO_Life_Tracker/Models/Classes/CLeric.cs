using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Cleric : AbstractDDOClass
    {
        public Cleric(int level) : base((int)DDOClasses.Cleric, nameof(Cleric), level, "cleric.png") { }
        public Cleric() : this(MIN_CLASS_LEVEL) { }
    }
}
