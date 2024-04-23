using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Morninglord : AbstractDDORace
    {
        public Morninglord() : base((int)DDORaces.Morninglord, nameof(Morninglord), "morninglord.png", true) { }
    }
}
