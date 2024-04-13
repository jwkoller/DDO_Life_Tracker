using DDO_Life_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Fighter : AbstractDDOClass
    {
        public Fighter() : base(102, nameof(Fighter), "fighter.png") { }
    }
}
