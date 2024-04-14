using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Blightcaster : AbstractDDOClass
    {
        public Blightcaster(int level) : base(111, nameof(Blightcaster), level, "blightcaster.png") { }
        public Blightcaster() : this(MIN_CLASS_LEVEL) { }
    }
}
