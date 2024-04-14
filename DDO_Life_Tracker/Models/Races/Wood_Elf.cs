using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Wood_Elf : AbstractDDORace
    {
        public Wood_Elf() : base(124, nameof(Wood_Elf).Replace("_", " "), "woodelf.png") { }
    }
}
