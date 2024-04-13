using DDO_Life_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Wizard : AbstractDDOClass
    {
        public Wizard(int level) : base(103, nameof(Wizard), level, "wizard.png") {  }
        public Wizard() : this(MIN_CLASS_LEVEL) { }
    }
}
