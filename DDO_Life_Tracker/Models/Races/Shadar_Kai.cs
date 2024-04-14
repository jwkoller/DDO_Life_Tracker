using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Shadar_Kai : AbstractDDORace
    {
        public Shadar_Kai() : base(118, nameof(Shadar_Kai).Replace("_", "-"), "shadar_kai.png", true) { }
    }
}
