using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models.Classes
{
    public class Monk : IClass
    {
        public int Id { get; }
        public string Name { get; }
        public int Level { get; set; } = 1;
        public string IconImgFileName { get; }
        public Monk() 
        {
            Id = 101;
            Name = nameof(Monk);
            IconImgFileName = "monk.png";
        }
    }
}
