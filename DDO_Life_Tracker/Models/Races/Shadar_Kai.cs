using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Shadar_Kai : AbstractDDORace
    {
        public Shadar_Kai() : base((int)DDORaces.Shadar__Kai, nameof(Shadar_Kai).Replace("_", "-"), "shadar_kai.png", true) { }
    }
}
