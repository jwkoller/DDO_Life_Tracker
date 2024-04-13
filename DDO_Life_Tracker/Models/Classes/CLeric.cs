using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Cleric : AbstractDDOClass
    {
        public Cleric(int level) : base(112, nameof(Cleric), level, "cleric.png") { }
        public Cleric() : this(MIN_CLASS_LEVEL) { }
    }
}
