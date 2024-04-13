using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Ranger : AbstractDDOClass
    {
        public Ranger(int level) : base(116, nameof(Ranger), level, "ranger.png") { }
        public Ranger() : this(MIN_CLASS_LEVEL) { }
    }
}
