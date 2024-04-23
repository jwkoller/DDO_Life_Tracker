﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Tiefling : AbstractDDORace
    {
        public Tiefling() : base((int)DDORaces.Tiefling, nameof(Tiefling), "tiefling.png") { }
    }
}
