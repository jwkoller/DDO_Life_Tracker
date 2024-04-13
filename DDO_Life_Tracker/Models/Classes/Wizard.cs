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
        public Wizard() : base(103, nameof(Wizard), "wizard.png") {  }
    }
}
