using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Dark_Apostate : AbstractDDOClass
    {
        public Dark_Apostate(int level) : base((int)DDOClasses.Dark_Apostate, nameof(Dark_Apostate).Replace("_", " "), level, "darkapostate.png") { }
        public Dark_Apostate() : this(MIN_CLASS_LEVEL) { }

    }
}
