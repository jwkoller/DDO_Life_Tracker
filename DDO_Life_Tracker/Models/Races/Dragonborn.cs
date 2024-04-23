using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Dragonborn : AbstractDDORace
    {
        public Dragonborn() : base((int)DDORaces.Dragonborn, nameof(Dragonborn), "dragonborn.png") { }
    }
}
