using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Acolyte_of_the_Skin : AbstractDDOClass
    {
        public Acolyte_of_the_Skin(int level) : base(120, nameof(Acolyte_of_the_Skin).Replace("_", " "), level, "acolyteoftheskin.png") { }
        public Acolyte_of_the_Skin() : this(MIN_CLASS_LEVEL) { }
    }
}
