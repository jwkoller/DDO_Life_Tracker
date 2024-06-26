﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public interface IClass : IHasImg
    {
        int Id { get; set; }
        int IncarnationId { get; set; }
        int ClassId { get; }
        string Name { get; }
        int Level { get; set; }
    }
}
