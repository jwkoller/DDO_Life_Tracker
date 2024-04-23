using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Druid : AbstractDDOClass
    {
        public Druid(int level) : base((int)DDOClasses.Druid, nameof(Druid), level, "druid.png") { }
        public Druid() : this(MIN_CLASS_LEVEL) { }
    }
}
