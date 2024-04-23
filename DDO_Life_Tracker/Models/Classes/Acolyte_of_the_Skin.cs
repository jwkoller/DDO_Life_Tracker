using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Acolyte_of_the_Skin : AbstractDDOClass
    {
        public Acolyte_of_the_Skin(int level) : base((int)DDOClasses.Acolyte_of_the_Skin, nameof(Acolyte_of_the_Skin).Replace("_", " "), level, "acolyteoftheskin.png") { }
        public Acolyte_of_the_Skin() : this(MIN_CLASS_LEVEL) { }
    }
}
