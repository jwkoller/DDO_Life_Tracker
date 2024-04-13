using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Barbarian : AbstractDDOClass
    {
        public Barbarian(int level) : base(109, nameof(Barbarian), level, "barbarian.png") { }
        public Barbarian() : this(MIN_CLASS_LEVEL) { }
    }
}
