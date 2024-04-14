using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Tiefling_Scoundrel : AbstractDDORace
    {
        public Tiefling_Scoundrel() : base(116, nameof(Tiefling_Scoundrel).Replace("_", " "), "scoundrel.png", true) { }
    }
}
