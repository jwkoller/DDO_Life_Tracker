using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public abstract class AbstractDDORace : IRace
    {
        public int Id { get; }
        public string Name { get; }
        public bool IsIconic { get; }
        public string IconImgFileName { get; }

        public AbstractDDORace(int id, string name,string iconImgFileName) : this(id, name, iconImgFileName, false) { }

        public AbstractDDORace(int id, string name, string iconImgFileName, bool isIconic)
        {
            Id = id;
            Name = name;
            IsIconic = isIconic;
            IconImgFileName = iconImgFileName;
        }
    }
}
