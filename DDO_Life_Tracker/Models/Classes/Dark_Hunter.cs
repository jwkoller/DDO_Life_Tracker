using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Dark_Hunter : AbstractDDOClass
    {
        public Dark_Hunter(int level) : base((int)DDOClasses.Dark_Hunter, nameof(Dark_Hunter).Replace("_", " "), level, "darkhunter.png") { }
        public Dark_Hunter() : this(MIN_CLASS_LEVEL) { }
    }
}
