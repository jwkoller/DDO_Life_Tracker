using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Aasimar : AbstractDDORace
    {
        public Aasimar() : base((int)DDORaces.Aasimar, nameof(Aasimar), "aasimar.png") { }
    }
}
