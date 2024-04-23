using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Razorclaw_Shifter : AbstractDDORace
    {
        public Razorclaw_Shifter() : base((int)DDORaces.Razorclaw_Shifter, nameof(Razorclaw_Shifter).Replace("_", " "), "razorclawshifter.png", true) { }
    }
}
