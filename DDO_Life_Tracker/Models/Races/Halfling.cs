using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Halfling : AbstractDDORace
    {
        public Halfling() : base(112, nameof(Halfling), "halfling.png") { }
    }
}
