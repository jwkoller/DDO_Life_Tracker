using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Dragon_Lord : AbstractDDOClass
    {
        public Dragon_Lord(int level) : base((int)DDOClasses.Dragon_Lord, nameof(Dragon_Lord).Replace("_", " "), level, "dragonlord.png") { }
        public Dragon_Lord() : this(MIN_CLASS_LEVEL) { }
    }
}
