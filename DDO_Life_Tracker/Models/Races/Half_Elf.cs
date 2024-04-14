using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Half_Elf : AbstractDDORace
    {
        public Half_Elf() : base(110, nameof(Half_Elf).Replace("_", " "), "half_elf.png") { }
    }
}
