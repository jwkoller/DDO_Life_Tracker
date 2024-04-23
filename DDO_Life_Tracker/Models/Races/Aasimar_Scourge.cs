using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Aasimar_Scourge : AbstractDDORace
    {
        public Aasimar_Scourge() : base((int)DDORaces.Aasimar_Scourge, nameof(Aasimar_Scourge).Replace("_", " "), "scourgeaasimar.png", true) { }
    }
}
