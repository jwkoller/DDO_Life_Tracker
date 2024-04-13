using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Alchemist : AbstractDDOClass
    {
        public Alchemist(int level) : base(107, nameof(Alchemist), level, "alchemist.png") { }
        public Alchemist() : this(MIN_CLASS_LEVEL) { }
    }
}
