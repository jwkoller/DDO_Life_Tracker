using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Stormsinger : AbstractDDOClass
    {
        public Stormsinger(int level) :base(119, nameof(Stormsinger), level, "stormsinger.png") { }
        public Stormsinger() : this(MIN_CLASS_LEVEL) { }
    }
}
