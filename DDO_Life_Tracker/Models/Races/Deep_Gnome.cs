using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Deep_Gnome : AbstractDDORace
    {
        public Deep_Gnome() : base(104, nameof(Deep_Gnome).Replace("_", " "), "deepgnome.png", true) { }
    }
}
