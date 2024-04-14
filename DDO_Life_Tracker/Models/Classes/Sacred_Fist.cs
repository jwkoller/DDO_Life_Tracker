using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Sacred_Fist : AbstractDDOClass
    {
        public Sacred_Fist(int level) : base(117, nameof(Sacred_Fist).Replace("_", " "), level, "sacredfist.png") { }
        public Sacred_Fist() : this(MIN_CLASS_LEVEL) { }
    }
}
