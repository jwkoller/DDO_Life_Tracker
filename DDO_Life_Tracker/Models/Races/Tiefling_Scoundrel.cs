using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Tiefling_Scoundrel : AbstractDDORace
    {
        public Tiefling_Scoundrel() : base((int)DDORaces.Tiefling_Scoundrel, nameof(Tiefling_Scoundrel).Replace("_", " "), "scoundrel.png", true) { }
    }
}
