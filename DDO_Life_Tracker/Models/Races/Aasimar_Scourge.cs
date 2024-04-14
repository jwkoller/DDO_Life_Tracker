using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Aasimar_Scourge : AbstractDDORace
    {
        public Aasimar_Scourge() : base(117, nameof(Aasimar_Scourge).Replace("_", " "), "scourgeaasimar.png", true) { }
    }
}
