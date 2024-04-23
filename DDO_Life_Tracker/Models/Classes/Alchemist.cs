using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Alchemist : AbstractDDOClass
    {
        public Alchemist(int level) : base((int)DDOClasses.Alchemist, nameof(Alchemist), level, "alchemist.png") { }
        public Alchemist() : this(MIN_CLASS_LEVEL) { }
    }
}
