using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Tabaxi_Trailblazer : AbstractDDORace
    {
        public Tabaxi_Trailblazer() : base(121, nameof(Tabaxi_Trailblazer).Replace("_", " "), "tabaxitrailblazer.png", true) { }
    }
}
