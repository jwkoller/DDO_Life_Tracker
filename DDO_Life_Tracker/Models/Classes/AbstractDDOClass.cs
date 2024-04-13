using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public abstract class AbstractDDOClass : IClass, IHasImg
    {
        public int Id { get; }
        public string Name { get; }
        public int Level { get; set; } = 1;
        public string IconImgFileName { get; }
        
        public AbstractDDOClass(int id, string name, string iconImgFileName)
        {
            Id = id;
            Name = name;
            IconImgFileName = iconImgFileName;
        }
    }
}
