using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Artificer : AbstractDDOClass
    {
        public Artificer(int level) : base((int)DDOClasses.Artificer, nameof(Artificer), level, "artificer.png") { }
        public Artificer() : this(MIN_CLASS_LEVEL) { }
    }
}
