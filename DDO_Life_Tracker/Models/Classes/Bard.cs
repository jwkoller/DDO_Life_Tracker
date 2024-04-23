using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Bard : AbstractDDOClass
    {
        public Bard(int level) : base((int)DDOClasses.Bard, nameof(Bard), level, "bard.png") { }
        public Bard() : this(MIN_CLASS_LEVEL) { }
    }
}
