using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Half_Orc : AbstractDDORace
    {
        public Half_Orc() : base(111, nameof(Half_Orc).Replace("_", " "), "half_orc.png") { }
    }
}
