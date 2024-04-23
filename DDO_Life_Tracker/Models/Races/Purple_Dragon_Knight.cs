using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Purple_Dragon_Knight : AbstractDDORace
    {
        public Purple_Dragon_Knight() : base((int)DDORaces.Purple_Dragon_Knight, nameof(Purple_Dragon_Knight).Replace("_", " "), "purpledragonknight.png", true) { }
    }
}
