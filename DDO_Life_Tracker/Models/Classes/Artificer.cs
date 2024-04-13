using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Artificer : AbstractDDOClass
    {
        public Artificer(int level) : base(108, nameof(Artificer), level, "artificer.png") { }
        public Artificer() : this(MIN_CLASS_LEVEL) { }
    }
}
