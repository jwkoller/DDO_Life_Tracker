using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Half_Orc : AbstractDDORace
    {
        public Half_Orc() : base((int)DDORaces.Half__Orc, nameof(Half_Orc).Replace("_", "-"), "half_orc.png") { }
    }
}
