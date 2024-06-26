﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public abstract class AbstractDDOClass : IClass
    {
        public int Id { get; set; }
        public int IncarnationId { get; set; }
        public int ClassId { get; }
        public string Name { get; }
        public int Level { get; set; }
        public string IconImgFileName { get; }

        protected const int MAX_CLASS_LEVEL = 20;
        protected const int MIN_CLASS_LEVEL = 1;

        protected AbstractDDOClass(int classId, string name, int level, string iconImgFileName)
        {
            ClassId = classId;
            Name = name;
            IconImgFileName = iconImgFileName;
            Level = ValidateClassLevel(level);
        }

        protected virtual int ValidateClassLevel(int level)
        {
            if(level > MAX_CLASS_LEVEL)
            {
                throw new Exception($"Class level {level} exceeds max {MAX_CLASS_LEVEL}.");
            }

            if(level < MIN_CLASS_LEVEL)
            {
                throw new Exception($"Class level {level} must be above {MIN_CLASS_LEVEL}");
            }

            return level;
        }
    }
}
