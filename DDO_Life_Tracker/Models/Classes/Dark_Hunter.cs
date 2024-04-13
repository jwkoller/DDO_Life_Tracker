using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Dark_Hunter : AbstractDDOClass
    {
        public Dark_Hunter() : base(114, nameof(Dark_Hunter).Replace("_",  " "), "darkhunter.png") { }
    }
}
