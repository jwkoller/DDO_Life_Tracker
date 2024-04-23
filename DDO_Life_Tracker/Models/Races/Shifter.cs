using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Shifter : AbstractDDORace
    {
        public Shifter() : base((int)DDORaces.Shifter, nameof(Shifter), "shifter.png") { }
    }
}
