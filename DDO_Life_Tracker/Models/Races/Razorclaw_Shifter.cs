using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Razorclaw_Shifter : AbstractDDORace
    {
        public Razorclaw_Shifter() : base(115, nameof(Razorclaw_Shifter).Replace("_", " "), "razorclawshifter.png", true) { }
    }
}
