﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDO_Life_Tracker.Services.Definitions;

namespace DDO_Life_Tracker.Models
{
    public class Blightcaster : AbstractDDOClass
    {
        public Blightcaster(int level) : base((int)DDOClasses.Blightcaster, nameof(Blightcaster), level, "blightcaster.png") { }
        public Blightcaster() : this(MIN_CLASS_LEVEL) { }
    }
}
