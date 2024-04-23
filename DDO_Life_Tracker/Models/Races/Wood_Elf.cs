using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Wood_Elf : AbstractDDORace
    {
        public Wood_Elf() : base((int)DDORaces.Wood_Elf, nameof(Wood_Elf).Replace("_", " "), "woodelf.png") { }
    }
}
