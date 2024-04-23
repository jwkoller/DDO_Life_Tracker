using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Deep_Gnome : AbstractDDORace
    {
        public Deep_Gnome() : base((int)DDORaces.Deep_Gnome, nameof(Deep_Gnome).Replace("_", " "), "deepgnome.png", true) { }
    }
}
