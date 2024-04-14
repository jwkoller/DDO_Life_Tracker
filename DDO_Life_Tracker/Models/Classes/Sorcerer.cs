using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Sorcerer : AbstractDDOClass
    {
        public Sorcerer(int level) : base(118, nameof(Sorcerer), level, "sorcerer.png") { }
        public Sorcerer() : this(MIN_CLASS_LEVEL) { }
    }
}
