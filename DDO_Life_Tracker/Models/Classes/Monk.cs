﻿using DDO_Life_Tracker.Models;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Monk : AbstractDDOClass
    {
        public Monk() : base(101, nameof(Monk), "monk.png") { }
    }
}
