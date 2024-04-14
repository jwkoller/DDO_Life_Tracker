using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Dark_Apostate : AbstractDDOClass
    {
        public Dark_Apostate(int level) : base(113, nameof(Dark_Apostate).Replace("_", " "), level, "darkapostate.png") { }
        public Dark_Apostate() : this(MIN_CLASS_LEVEL) { }

    }
}
