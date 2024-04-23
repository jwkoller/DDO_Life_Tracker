using DDO_Life_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Fighter : AbstractDDOClass
    {
        public Fighter(int level) : base((int)DDOClasses.Fighter, nameof(Fighter), level, "fighter.png") { }
        public Fighter() : this(MIN_CLASS_LEVEL) { }
    }
}
