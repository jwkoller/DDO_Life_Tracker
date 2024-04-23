using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Half_Elf : AbstractDDORace
    {
        public Half_Elf() : base((int)DDORaces.Half__Elf, nameof(Half_Elf).Replace("_", "-"), "half_elf.png") { }
    }
}
