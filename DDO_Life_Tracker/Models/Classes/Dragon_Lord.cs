using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models.Classes
{
    public class Dragon_Lord : AbstractDDOClass
    {
        public Dragon_Lord(int level) : base(121, nameof(Dragon_Lord).Replace("_", " "), level, "fighter.png") { }
        public Dragon_Lord() : this(MIN_CLASS_LEVEL) { }
    }
}
