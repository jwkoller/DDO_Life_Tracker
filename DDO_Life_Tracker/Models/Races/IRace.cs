using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public interface IRace : IHasImg
    {
        int Id { get; }
        string Name { get; }
        bool IsIconic { get; }
    }
}
