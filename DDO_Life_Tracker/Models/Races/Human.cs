﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Human : IRace
    {
        public int Id { get; }
        public string Name { get; }
        public bool IsIconic { get; }
        public string IconImgFileName { get; }
        public Human() 
        {
            Id = 101;
            Name = nameof(Human);
            IsIconic = false;
            IconImgFileName = "human.png";
        }
    }
}
