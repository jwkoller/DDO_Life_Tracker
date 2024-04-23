using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Stormsinger : AbstractDDOClass
    {
        public Stormsinger(int level) :base((int)DDOClasses.Stormsinger, nameof(Stormsinger), level, "stormsinger.png") { }
        public Stormsinger() : this(MIN_CLASS_LEVEL) { }
    }
}
