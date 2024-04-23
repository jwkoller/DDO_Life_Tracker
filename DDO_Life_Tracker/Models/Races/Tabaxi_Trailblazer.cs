using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Tabaxi_Trailblazer : AbstractDDORace
    {
        public Tabaxi_Trailblazer() : base((int)DDORaces.Tabaxi_Trailblazer, nameof(Tabaxi_Trailblazer).Replace("_", " "), "tabaxitrailblazer.png", true) { }
    }
}
