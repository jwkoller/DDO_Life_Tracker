using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Favored_Soul : AbstractDDOClass
    {
        public Favored_Soul(int level) : base(115, nameof(Favored_Soul).Replace("_", " "), level, "favoredsoul.png") { }
        public Favored_Soul() : this(MIN_CLASS_LEVEL) { }
    }
}
