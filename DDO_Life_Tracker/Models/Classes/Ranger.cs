using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Ranger : AbstractDDOClass
    {
        public Ranger(int level) : base((int)DDOClasses.Ranger, nameof(Ranger), level, "ranger.png") { }
        public Ranger() : this(MIN_CLASS_LEVEL) { }
    }
}
