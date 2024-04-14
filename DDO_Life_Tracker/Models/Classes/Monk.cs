using DDO_Life_Tracker.Models;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Monk : AbstractDDOClass
    {
        public Monk(int level) : base(101, nameof(Monk), level, "monk.png") { }
        public Monk() : this(MIN_CLASS_LEVEL) { }
    }
}
